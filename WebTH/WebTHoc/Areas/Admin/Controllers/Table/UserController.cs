using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace WebTHoc.Areas.Admin.Controllers
{
    public class UserController : BaseController<User>
    {
        // GET: Admin/User
        [HttpPost]
        public override ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var u = new UserDAO();
                user.Password = Encryptor.MD5Hash(user.Password);
                long result = u.Insert(user);
                if (result > 0)
                {
                    return RedirectToAction("Index", "User");
                }else
                {
                    ModelState.AddModelError("","Thêm không thành công");
                }
            }
            return View("Create");
        }

        [HttpPost]
        public override ActionResult Edit(User user)
        {
            var list = new UserDAO();
            if (ModelState.IsValid)
            {
                var a = RouteData.Values["id"];
                var lbh1 = list.SelectWhere("ID ==" + a).FirstOrDefault();
                if (lbh1.Password != user.Password)
                {
                    user.Password = Encryptor.MD5Hash(user.Password);
                    list.Update(user,lbh1);
                    return RedirectToAction("Index");
                }
                else
                {
                    list.Update(user, lbh1);
                }
            }
            return View("Edit");
            
            
        }
    }
}