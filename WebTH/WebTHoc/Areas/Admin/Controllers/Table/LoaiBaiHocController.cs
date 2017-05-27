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
    public class LoaiBaiHocController : BaseController<LoaiBaiHoc>
    {
        // GET: Admin/LoaiBaiHoc
        [Authorize]
        [HasCredential(RoleID = "VIEW_LOAIBAIHOC")]
        public override ActionResult Index()
        {
            return base.Index();
        }
        [HasCredential(RoleID = "ADD_LOAIBAIHOC")]
        [Authorize]
        public override ActionResult Create()
        {
            SetViewBag();
            return base.Create();
        }

        [HasCredential(RoleID = "EDIT_LOAIBAIHOC")]
        [Authorize]
        public override ActionResult Edit(int id)
        {
            SetViewBag(id);
            return base.Edit(id);
        }

        public void SetViewBag(long? select=null)
        {
            ViewBag.IDCha = new SelectList(new LoaiBaiHocDAO().SelectAll(), "ID", "Ten", select);
        }
    }
}