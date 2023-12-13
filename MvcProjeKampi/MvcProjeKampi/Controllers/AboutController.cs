using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager repo = new AboutManager(new AboutRepository());
        public ActionResult Index()
        {

            return View(repo.TGetList());
        }

        [HttpGet]
        public PartialViewResult AddAbout()
        {

            return PartialView();
        }
        [HttpPost]
        public ActionResult AboutAdd(About p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
     







    }
}