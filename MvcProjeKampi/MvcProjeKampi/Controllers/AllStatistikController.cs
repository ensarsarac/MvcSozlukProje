using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [Authorize(Roles =("A"))]
    public class AllStatistikController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            ViewBag.v1 = c.Headings.GroupBy(x => x.CategoryID).Count();
            ViewBag.v2 = c.Headings.Where(x => x.CategoryID == 6).Count();
            ViewBag.v3 = c.Writers.Where(x => x.Name.Contains("a")).Count();
            //ViewBag.v4 = c.Headings.Select(x => x.CategoryID).GroupBy();
            var betrue = c.Categories.Where(x => x.Status == true).Count();
            var befalse = c.Categories.Where(x => x.Status == false).Count();
            ViewBag.v5 = betrue - befalse;

            return View();
        }
    }
}