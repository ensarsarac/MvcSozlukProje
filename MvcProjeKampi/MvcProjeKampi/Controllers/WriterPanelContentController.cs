using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new ContentRepository());
        public ActionResult MyContent()
        {
            Context c = new Context();
            var user = c.Writers.Where(x => x.Mail == User.Identity.Name).FirstOrDefault();
            var values = cm.GetListByWriter(user.WriterID);
            return View(values);
        }
    }
}