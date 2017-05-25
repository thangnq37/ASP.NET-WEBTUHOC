using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTHoc.Areas.Admin.Models;
using Model;
using WebTHoc.Areas.Admin.Core;
using System.Web.Security;

namespace WebTHoc.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
           // var result = new UserDAO().Login(model.UserName, model.Password); ;
            if(Membership.ValidateUser(model.UserName, model.Password) && ModelState.IsValid)
            {
                //SessionHelper.SetSession(new UserSession() { UserName = model.UserName});
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                var userSession = new UserLogin();
                ModelController<Model.EF.User> u = new UserDAO();
                Model.EF.User user = u.SelectWhere("Username ==" + model.UserName).FirstOrDefault();
                userSession.UserID =user.ID;
                userSession.UserName = user.HoTen;

                Session.Add(CommonConstants.USER_SESSION,user);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Login");
        }
    }
}