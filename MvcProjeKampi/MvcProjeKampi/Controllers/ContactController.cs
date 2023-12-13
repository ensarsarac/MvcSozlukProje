using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new ContactRepository());
        MessageManager mm = new MessageManager(new MessageRepository());
        public ActionResult Index()
        {
            ViewBag.v = cm.TGetList().Count();
            ViewBag.vTotal = cm.TGetList().Count();

            return View(cm.TGetList());
        }

        public PartialViewResult SideBarMessage()
        {
            Context c = new Context();
            ViewBag.v = cm.TGetList().Where(x=>x.IsRead == false).Count();
            var admin = c.Admins.FirstOrDefault(x=>x.UserName == User.Identity.Name);
            ViewBag.v1 = mm.TGetList().Where(x => x.ReceiverMail == admin.UserName.ToString() && x.IsRead == false).Count();
            //ViewBag.v2 = mm.GetSendBox().Count();
            return PartialView();
        }

        public ActionResult ReadMail(int id)
        {
            var values = cm.TGetById(id);
            values.IsRead = true;
            cm.TUpdate(values);
            return View(cm.TGetById(id));
        }

        [HttpGet]
        public PartialViewResult AddContact()
        {

            return PartialView();
        }

        [HttpPost]
        public ActionResult AddContact(Contact p)
        {
            p.IsRead = false;
            p.Date = DateTime.Now;
            System.Threading.Thread.Sleep(100);
            cm.TAdd(p);        
            return RedirectToAction("Index","Home");
        }


    }
}