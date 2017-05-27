using Model;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTHoc.Areas.Admin.Controllers
{
    public class BaiHocController : BaseController<BaiHoc>
    {
        [Authorize]
        [HasCredential(RoleID = "VIEW_BAIHOC")]
        public override ActionResult Index()
        {
            return base.Index();
        }
        [Authorize]
        [HasCredential(RoleID = "ADD_BAIHOC")]
        // GET: Admin/BaiHoc
        public override ActionResult Create()
        {
            SetViewBag();
            return base.Create();
        }
        [Authorize]
        [HasCredential(RoleID = "EDIT_BAIHOC")]
        public override ActionResult Edit(int id)
        {
            SetViewBag(id);
            return base.Edit(id);
        }

        public void SetViewBag(long? select = null)
        {
            ViewBag.IDLoaiBaiHoc = new SelectList(new LoaiBaiHocDAO().SelectAll(), "ID", "Ten", select);
        }
    }
}