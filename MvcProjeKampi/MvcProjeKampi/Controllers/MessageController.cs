using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation.Messages;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new MessageRepository());
        Context c = new Context();
        public ActionResult Inbox(string searchmail)
        {
            ViewBag.adminmail = mm.TGetList().Where(x => x.ReceiverMail == User.Identity.Name).Count();
            var onlineuser = c.Admins.FirstOrDefault(x => x.UserName == User.Identity.Name);
            if (!String.IsNullOrEmpty(searchmail))
            {
                return View(mm.GetInBox(onlineuser.UserName.ToString()).Where(x => x.SenderMail.Contains(searchmail)).ToList());
            }
            else
            {
                return View(mm.GetInBox(onlineuser.UserName.ToString()));
            }


        }

        public ActionResult SendBox(string searchmail)
        {
            var onlineuser = c.Admins.FirstOrDefault(x => x.UserName == User.Identity.Name);
            ViewBag.totalmessage = mm.TGetList().Where(x => x.SenderMail == User.Identity.Name).Count();

            if (!String.IsNullOrEmpty(searchmail))
            {
                return View(mm.GetSendBox(onlineuser.UserName.ToString()).Where(x => x.ReceiverMail.Contains(searchmail)).ToList());
            }
            else
            {
                return View(mm.GetSendBox(onlineuser.UserName.ToString()));
            }


        }

        public ActionResult ReadMail(int id)
        {
            var values = mm.TGetById(id);
            values.IsRead = true;
            mm.TUpdate(values);
            return View(mm.TGetById(id));
        }

        [HttpGet]
        public ActionResult WriteMessage()
        {
            Message m = new Message();
            return View(m);
        }

        [HttpPost]
        public ActionResult WriteMessage(Message p)
        {
            AddMessageValidator rules = new AddMessageValidator();
            ValidationResult result = rules.Validate(p);
            if (result.IsValid)
            {
                p.Status = true;
                p.MessageDate = DateTime.Now;
                p.SenderMail = User.Identity.Name.ToString();
                mm.TAdd(p);
                return RedirectToAction("Inbox");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(p);
            }

        }

        public ActionResult Draft()
        {
            return View();
        }

        public ActionResult SaveDraft(string ReceiverMail)
        {

            Message m = new Message()
            {
                Content = "",
                Status = false,
                MessageDate = DateTime.Now,
                ReceiverMail = ReceiverMail,
                Subject = "",
                SenderMail = "admin@gmail.com"
            };

            mm.TAdd(m);
            return RedirectToAction("Draft");
        }



        public ActionResult DeleteMessage()
        {

            return View(mm.TGetList().Where(x => x.Status == false).ToList());
        }
        public ActionResult DeleteMessage2(int id)
        {
            var value = mm.TGetById(id);
            value.Status = false;
            mm.TUpdate(value);
            return RedirectToAction("Inbox");
        }


    }
}