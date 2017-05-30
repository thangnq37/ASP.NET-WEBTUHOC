using Model;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTHoc.Areas.Admin.Controllers
{   
    [Authorize]
    public class CredentialController : BaseController<Credential>
    {
        // GET: Admin/Credential
        
        [HasCredential(RoleID ="VIEW_CREDENTIAL")]
        public override ActionResult Index()
        {
            return base.Index();
        }
 
        [HasCredential(RoleID = "ADD_CREDENTIAL")]
        public override ActionResult Create()
        {
            ViewBagData();
            return base.Create();
        }

        [HttpGet]
        public override ActionResult Delete(int id)
        {
            var a = new Credential();
            a.RoleID = Request.QueryString[0];
            a.UserGroupID = Request.QueryString[1];
            var b = new CredentialDAO().Delete(a);
            if (b && ModelState.IsValid)
                ModelState.AddModelError("","Xóa Thành Công");
            else
                ModelState.AddModelError("", "Không Thể Xóa");
            return RedirectToAction("Index");
        }

        //[HasCredential(RoleID = "EDIT_CREDENTIAL")]
        //public ActionResult Edit(string a, string b)
        //{
        //    ViewBagData(a, b);
        //    return View();
        //}
        //public override ActionResult Edit(Credential lbh)
        //{   
        //    return base.Edit(lbh);
        //}
        public void ViewBagData(string idG=null,string idR=null)
        {
            ViewBag.RoleID = new SelectList(new RoleDAO().SelectAll(),"ID", "ID", idR);
            ViewBag.UserGroupID = new SelectList(new UserGroupDAO().SelectAll(),"ID", "ID", idG);
        }
    }
}