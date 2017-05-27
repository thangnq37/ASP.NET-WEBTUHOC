using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace WebTHoc.Areas.Admin.Controllers
{
    [Authorize]
    public class UserController : BaseController<User>
    {

        [HasCredential(RoleID = "VIEW_USER")]
        public override ActionResult Index()
        {
            return base.Index();
        }
        [HasCredential(RoleID = "ADD_USER")]
        public override ActionResult Create()
        {
            return base.Create();
        }
        // GET: Admin/User
        [HttpPost]
        public override ActionResult Create(User user)
        {
            var s = SeeUser(user);
            if (ModelState.IsValid && s == 1)
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
            else
            {
                if (s == -1)
                {
                    ModelState.AddModelError("", "Username đã có người dùng");
                }
                else
                {
                    ModelState.AddModelError("", "Email đã có người dùng");
                }
            }

            return View("Create");
        }
        [HasCredential(RoleID = "EDIT_USER")]
        public override ActionResult Edit(int id)
        {
            var a = new UserDAO().SelectWhere("ID ==" + id).First();
            ViewBag.GroupID = new SelectList(new UserGroupDAO().SelectAll(),"GroupID","GroupID",a.GroupID);
            return base.Edit(id);
        }

        [HttpPost]
        public override ActionResult Edit(User user)
        {
            var s = SeeUser(user);
            var list = new UserDAO();
            if (ModelState.IsValid && s == 1)
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
            else
            {
                if (s == -1)
                {
                    ModelState.AddModelError("", "Username đã có người dùng");
                }
                else
                {
                    ModelState.AddModelError("", "Email đã có người dùng");
                }
            }
            return View("Edit");
            
            
        }

        private int SeeUser(User u)
        {
            var db = new UserDAO();
            var a = Base.Instance.User.Where(x=>x.UserName==u.UserName).Count();
            var b = Base.Instance.User.Where(x => x.Email == u.Email).Count();
            if(a == 0 && b == 0)
            {
                return 1;
            }
            else
            {
                if (a > 0)
                    return -1;//username trung
                else if (b > 0)
                    return -2;//Email trung
            }
            return 0;
        }
    }
}