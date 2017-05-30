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
        [HasCredential(RoleID = "VIEW_LOAIBAIHOC")]
        public override ActionResult Index()
        {
            return base.Index();
        }
        [HasCredential(RoleID = "ADD_LOAIBAIHOC")]
        public override ActionResult Create()
        {
            SetViewBag();
            return base.Create();
        }

        [HasCredential(RoleID = "EDIT_LOAIBAIHOC")]
        public override ActionResult Edit(int id)
        {
            SetViewBag(id);
            return base.Edit(id);
        }

        public override ActionResult Edit(LoaiBaiHoc lbh)
        {
            lbh.ModifiedDate = DateTime.Now;
            lbh.ModifiedBy = GetUser().UserName;
            return base.Edit(lbh);
        }

        public override ActionResult Create(LoaiBaiHoc lbh)
        {
            lbh.CreatedDate = DateTime.Now;
            lbh.CreatedBy = GetUser().UserName;
            return base.Create(lbh);
        }

        public void SetViewBag(long? select=null)
        {
            ViewBag.IDCha = new SelectList(new LoaiBaiHocDAO().SelectAll(), "ID", "Ten", select);
        }

        private UserLogin GetUser()
        {
            return Session[CommonConstants.USER_SESSION] as UserLogin;
        }
    }
}