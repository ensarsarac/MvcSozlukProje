using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new ContentRepository());
        HeadingManager hm = new HeadingManager(new HeadingRepository());
        [HttpGet]
        public ActionResult Index(int id)
        {
            ViewBag.v = hm.TGetById(id).Name;
            return View(cm.TGetList().Where(x=>x.HeadingID==id).ToList());
        }
    }
}