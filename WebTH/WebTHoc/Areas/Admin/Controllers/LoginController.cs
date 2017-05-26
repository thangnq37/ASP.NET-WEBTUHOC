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
            var result = new UserDAO().Login(model.UserName, Encryptor.MD5Hash(model.Password)); ;
            if(result == 1 && ModelState.IsValid)
            {
                //SessionHelper.SetSession(new UserSession() { UserName = model.UserName});
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                var userSession = new UserLogin();
                Model.EF.User user= new UserDAO().GetByID(model.UserName);
                userSession.UserID =user.ID;
                userSession.UserName = user.HoTen;
          
                Session.Add(CommonConstants.USER_SESSION,user);
                return RedirectToAction("Index", "Home");
            }
            else if(result == 0)
            {
                ModelState.AddModelError("", "Tài khoản không tồn tại");
            }else if(result == -1)
            {
                ModelState.AddModelError("", "Tài khoản bị khóa");
            }else if(result == -2)
                ModelState.AddModelError("", "Mật khẩu không hợp lệ");
            else
                ModelState.AddModelError("", "Username không hợp lệ");
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Login");
        }
    }
}