using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTHoc.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : BaseController<object>
    {
        // GET: Admin/Home
        public override ActionResult Index()
        {
            return View();
        }
    }
}