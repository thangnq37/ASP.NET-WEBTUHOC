using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Model.EF;

namespace WebTHoc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string searchBaiHoc, int page = 1, int pageSize=10)
        {
            var lbh = new Model.LoaiBaiHocDAO();
            ViewData["MenuList"] = lbh.SelectAll();
            var model = new BaiHocDAO().GetListPage(searchBaiHoc, page, pageSize);
            ViewBag.Search = searchBaiHoc;
            ViewData["MenuRight"] = lbh.SelectAll().Where(x => x.IDCha != null).ToList();
            return View(model);
        }
        
        public ActionResult Lession(int page=1,int pageSize=10)
        {
            var id = int.Parse(Request.QueryString["id"]);
            var lbh = new Model.LoaiBaiHocDAO();
            ViewData["MenuList"] = lbh.SelectAll();
            ViewData["MenuRight"] = lbh.SelectAll().Where(x => x.IDCha == id).ToList();
            IEnumerable<Model.EF.BaiHoc> model = new BaiHocDAO().GetListPageLession(page, pageSize,id);
            return View(model);
        }

        public ActionResult DetailLession()
        {
            ViewData["MenuList"] = new Model.LoaiBaiHocDAO().SelectAll();
            var id = int.Parse(Request.QueryString["id"]);
            BaiHoc bh = new BaiHocDAO().SelectWhere("ID ==" + id).First();
            ViewData["lsBaiHoc"] = new BaiHocDAO().SelectAll().Where(x => x.IDLoaiBaiHoc == bh.IDLoaiBaiHoc).OrderByDescending(a=>a.ID).ToList();
            return View(bh);
        }

        public ActionResult LessionType(int page = 1, int pageSize = 10)
        {
            var ls = new Model.LoaiBaiHocDAO();
            var id = int.Parse(Request.QueryString["id"]);
            ViewData["MenuList"] =ls.SelectAll();
            ViewData["LoaiBaiHoc"] = ls.SelectWhere("ID==" + id).First();
            IEnumerable<Model.EF.BaiHoc> model = new BaiHocDAO().GetListPageLessionType(page, pageSize, id);
            return View(model);
        }



    }
}