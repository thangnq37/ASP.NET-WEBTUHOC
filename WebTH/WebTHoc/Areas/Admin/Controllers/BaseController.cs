using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Model;

namespace WebTHoc.Areas.Admin.Controllers
{
    public class BaseController<m> : Controller where m : class, new()
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" }));
            }
            base.OnActionExecuting(filterContext);
        }

        private object GetController()
        {
            m t = new m();
            if (t is LoaiBaiHoc)
                return new LoaiBaiHocDAO();
            else if (t is BaiHoc)
                return new BaiHocDAO();
            else if (t is BinhLuan)
                return new BinhLuanDAO();
            else if (t is BaiHocTag)
                return new BaiHocTagDAO();
            else if (t is Like)
                return new LikeDAO();
            else if (t is User)
                return new UserDAO();
            else if (t is Tag)
                return new TabDAO();
            else if (t is Credential)
                return new CredentialDAO();
            else if (t is Role)
                return new RoleDAO();
            else if (t is UserGroup)
                return new UserGroupDAO();
            else
                return null;
        }
        private string getUrl()
        {
            return null;
        }
        [Authorize]
        // GET: Admin/Default
        public virtual ActionResult Index()
        {
            ModelController<m> list = GetController() as ModelController<m>;
            var ls = list.SelectAll();
            return View(ls);
        }
        [Authorize]

        public virtual ActionResult Create()
        {
            ModelController<m> list = GetController() as ModelController<m>;
            return View();
        }
        [Authorize]

        [HttpPost, ValidateInput(false)]
        public virtual ActionResult Create(m lbh)
        {
            ModelController<m> list = GetController() as ModelController<m>;
            if (ModelState.IsValid)
            {
                if (list.Insert(lbh))
                {
                    return RedirectToAction("index");
                }
                else
                {
                    ModelState.AddModelError("","Không thể thực hiệ");
                }
            }
            return View("Create");

        }
        [Authorize]

        public virtual ActionResult Edit(int id)
        {
            ModelController<m> list = GetController() as ModelController<m>;
            var lbh = list.SelectWhere("ID ==" + id).FirstOrDefault();
            return View(lbh);
        }
        [Authorize]

        [HttpPost, ValidateInput(false)]
        public virtual ActionResult Edit(m lbh)
        {
            ModelController<m> list = GetController() as ModelController<m>;

            var a = RouteData.Values["id"];
            var lbh1 = list.SelectWhere("ID ==" + a).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (list.Update(lbh, lbh1))
                {
                    return RedirectToAction("index");
                }
                else
                {
                    ModelState.AddModelError("", "Không thể thực hiệ");
                }
            }
            return View("Edit");
        }
        [Authorize]
        [HttpGet]
        public virtual ActionResult Delete(int id)
        {
            ModelController<m> list = GetController() as ModelController<m>;
            var a = RouteData.Values["id"];
            var lbh1 = list.SelectWhere("ID ==" + a).FirstOrDefault();
            list.Delete(lbh1);
            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpGet]
        public virtual ActionResult Details(int id)
        {
            ModelController<m> list = GetController() as ModelController<m>;
            var a = RouteData.Values["id"];
            var lbh1 = list.SelectWhere("ID ==" + a).FirstOrDefault();
            return View(lbh1);
        }
    }
}