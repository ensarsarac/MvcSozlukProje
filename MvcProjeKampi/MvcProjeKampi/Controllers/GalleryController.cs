using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        WriterManager wm = new WriterManager(new WriterRepository());
        public ActionResult Index()
        {
            return View(wm.TGetList());
        }
    }
}