using Model;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTHoc.Areas.Admin.Controllers.Table
{
    public class BinhLuanController : BaseController<BinhLuan>
    {
        // GET: Admin/BinhLuan
        [Authorize]
        [HasCredential(RoleID = "VIEW_BINHLUAN")]
        public override ActionResult Index()
        {
            return base.Index();
        }
        [Authorize]
        [HasCredential(RoleID = "ADD_BINHLUAN")]
        public override ActionResult Create()
        {
            ViewBagID();
            return base.Create();
        }
        [Authorize]
        [HasCredential(RoleID = "EDIT_BINHLUAN")]
        public override ActionResult Edit(int id)
        {
            ViewBagID(id);
            return base.Edit(id);
        }

        private void ViewBagID(long? select=null)
        {
            ViewBag.BaiHocID = new SelectList(new BaiHocDAO().SelectAll(), "ID", "TieuDe", select);
            ViewBag.UserID = new SelectList(new UserDAO().SelectAll(), "ID", "UserName", select);
        }
    }
}