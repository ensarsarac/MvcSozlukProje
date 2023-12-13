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
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager(new MessageRepository());
        [HttpGet]
        public ActionResult Inbox(string searchmail)
        {
            ViewBag.totalmail = mm.GetInBox(User.Identity.Name).Count();
            if (!String.IsNullOrEmpty(searchmail))
            {
                var values = mm.GetInBox(User.Identity.Name).Where(x => x.SenderMail.Contains(searchmail) && x.Status==true).ToList();
                return View(values);
            }
            else
            {
                var p = (string)Session["Mail"];
                return View(mm.GetInBox(User.Identity.Name));
            }

        }

        public PartialViewResult SideBar()
        {
            Context c = new Context();
            ViewBag.v1 = mm.TGetList().Where(x => x.ReceiverMail == User.Identity.Name.ToString() && x.IsRead == false).Count();
            return PartialView();
        }

        public ActionResult ReadMail(int id)
        {
            var values = mm.TGetById(id);
            values.IsRead = true;
            mm.TUpdate(values);
            return View(mm.TGetById(id));
        }


        public ActionResult Sendbox(string searchmail)
        {
            ViewBag.totalmessage = mm.GetSendBox(User.Identity.Name).Count();

            if (!String.IsNullOrEmpty(searchmail))
            {
                var values = mm.GetSendBox(User.Identity.Name).Where(x => x.SenderMail.Contains(searchmail) && x.Status==true).ToList();
                return View(values);
            }
            else
            {
                return View(mm.GetSendBox(User.Identity.Name)); 
            }
            
        }


        public ActionResult DeleteMessage(int id)
        {
            var value = mm.TGetById(id);
            value.Status = false;
            mm.TUpdate(value);
            return RedirectToAction("Inbox");
        }

        public ActionResult Trash()
        {
            var value = mm.TGetList().Where(x => x.ReceiverMail == User.Identity.Name || x.SenderMail == User.Identity.Name && x.Status == false).ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult SendMessage()
        {

            return View(new Message());
        }

        [HttpPost]
        public ActionResult SendMessage(Message p)
        {
            p.SenderMail = User.Identity.Name;
            p.MessageDate = DateTime.Now;
            p.Status = true;
            p.IsRead = false;
            mm.TAdd(p);
            return RedirectToAction("Inbox");
        }

    }
}