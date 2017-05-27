using Model;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTHoc.Areas.Admin.Controllers
{   
    
    public class CredentialController : BaseController<Credential>
    {
        // GET: Admin/Credential
        [Authorize]
        [HasCredential(RoleID ="VIEW_CREDENTIAL")]
        public override ActionResult Index()
        {
            return base.Index();
        }
        [Authorize]
        [HasCredential(RoleID = "ADD_CREDENTIAL")]
        public override ActionResult Create()
        {
            ViewBagData();
            return base.Create();
        }
        [Authorize]
        public override ActionResult Create(Credential lbh)
        {
            ViewBagData(lbh.UserGroupID, lbh.RoleID);
            return base.Create(lbh);
        }
        [Authorize]
        [HasCredential(RoleID = "EDIT_CREDENTIAL")]
        public override ActionResult Edit(Credential lbh)
        {   
            ViewBagData(lbh.UserGroupID, lbh.RoleID);
            return base.Edit(lbh);
        }
        public void ViewBagData(string idG=null,string idR=null)
        {
            ViewBag.RoleID = new SelectList(new RoleDAO().SelectAll(),"ID", "ID", idR);
            ViewBag.UserGroupID = new SelectList(new UserGroupDAO().SelectAll(),"ID", "ID", idG);
        }
    }
}