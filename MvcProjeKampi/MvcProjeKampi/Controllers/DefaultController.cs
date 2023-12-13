using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new HeadingRepository());
        ContentManager cm = new ContentManager(new ContentRepository());
        public PartialViewResult SideBar()
        {

            //var value = cm.TGetList().GroupBy(x => x.HeadingID).Select(s => s.Key).ToList();
            return PartialView(hm.TGetList().OrderByDescending(x=>x.HeadingDate).ToList()); 
        }
        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }



        public ActionResult Index()
        {
            return View(cm.TGetList());
        }

        public ActionResult HeadingContent(int id)
        {
            ViewBag.heading = hm.TGetById(id).Name;
            return View(cm.TGetList().Where(x=>x.HeadingID == id).ToList());
        }



    }
}