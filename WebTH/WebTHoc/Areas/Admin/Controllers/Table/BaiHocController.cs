using Model;
using Model.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTHoc.Areas.Admin.Controllers
{
    [Authorize]
    public class BaiHocController : BaseController<BaiHoc>
    {
        [HasCredential(RoleID = "VIEW_BAIHOC")]
        public override ActionResult Index()
        {
            return base.Index();
        }
        
        [HasCredential(RoleID = "ADD_BAIHOC")]
        // GET: Admin/BaiHoc
        public override ActionResult Create()
        {
            SetViewBag();
            return base.Create();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CreateImage(BaiHoc lbh, HttpPostedFileBase uploadEditorImage)
        {
            if (uploadEditorImage != null)
            {
                lbh.UrlHinh = "/Content/Image/" + uploadEditorImage.FileName;
                GetPathImage(uploadEditorImage);
            }
            lbh.CreatedBy = GetUser().UserName;
            lbh.CreatedDate = DateTime.Now;
            return base.Create(lbh);
        }

        [HasCredential(RoleID = "EDIT_BAIHOC")]
        public override ActionResult Edit(int id)
        {
            SetViewBag(id);
            return base.Edit(id);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EditImage(BaiHoc lbh, HttpPostedFileBase uploadEditorImage)
        {
            if (uploadEditorImage != null)
            {
                lbh.UrlHinh = "/Content/Image/" + uploadEditorImage.FileName;
                GetPathImage(uploadEditorImage);
            }
            lbh.ModifiedBy = GetUser().UserName;
            lbh.ModifiedDate = DateTime.Now;
            var list = new Model.BaiHocDAO();
            var lbh1 = list.SelectWhere("ID ==" + lbh.ID).FirstOrDefault();
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

        public void SetViewBag(long? select = null)
        {
            ViewBag.IDLoaiBaiHoc = new SelectList(new LoaiBaiHocDAO().SelectAll(), "ID", "Ten", select);
        }
        /// <summary>
        /// Lấy User hiện tại
        /// </summary>
        /// <returns></returns>
        private UserLogin GetUser()
        {
            return Session[CommonConstants.USER_SESSION] as UserLogin;
        }
        /// <summary>
        /// Lấy link image anh upload
        /// </summary>
        /// <param name="uploadEditorImage"></param>
        /// <returns></returns>
        private string GetPathImage(HttpPostedFileBase uploadEditorImage)
        {
            var path = "";
            if (uploadEditorImage != null)
            {
                if (uploadEditorImage.ContentLength > 0)
                {
                    if (Path.GetExtension(uploadEditorImage.FileName).ToLower() == ".jpg" || Path.GetExtension(uploadEditorImage.FileName).ToLower() == ".png" ||
                        Path.GetExtension(uploadEditorImage.FileName).ToLower() == ".gif" || Path.GetExtension(uploadEditorImage.FileName).ToLower() == ".jpeg")
                    {
                        path = Path.Combine(Server.MapPath("~/Content/Image"), uploadEditorImage.FileName);
                        uploadEditorImage.SaveAs(path);
                    }
                }
            }
            return path;
        }
    }
}