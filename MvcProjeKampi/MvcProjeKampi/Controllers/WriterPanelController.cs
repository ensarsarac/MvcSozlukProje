using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.EntityFramework.Repository;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new HeadingRepository());
        WriterManager wm = new WriterManager(new WriterRepository());
        CategoryManager cm = new CategoryManager(new CategoryRepository());
        ContentManager contentrepo = new ContentManager(new ContentRepository());

        [HttpGet]
        public ActionResult WriterProfile()
        {
            var user = wm.TGetWriterByMail(User.Identity.Name);
            return View(user);
        }

        [HttpGet]
        public ActionResult UserEditProfile(int id)
        {
            var user = wm.TGetById(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult UserEditProfile(Writer p)
        {
            WriterValidator rules = new WriterValidator();
            ValidationResult result = rules.Validate(p);
            if (result.IsValid)
            {
                var user = wm.TGetById(p.WriterID);
                user.Name = p.Name;
                user.Surname = p.Surname;
                user.Image = p.Image;
                user.About = p.About;
                user.Title = p.Title;
                user.Mail = p.Mail;
                wm.TUpdate(user);

                if(user.Password != p.Password)
                {
                    user.Password = p.Password;
                    wm.TUpdate(user);
                    FormsAuthentication.SignOut();
                    Session.Abandon();
                    return RedirectToAction("WriterLogin", "Login");
                }

                return RedirectToAction("WriterProfile", "WriterPanel");
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

        public PartialViewResult SideBarPartial()
        {
            Context c = new Context();
            ViewBag.admin = c.Writers.FirstOrDefault(x => x.Mail == User.Identity.Name);
            return PartialView();
        }

        public ActionResult MyHeading()
        {
            var values = hm.GetListByWriter(User.Identity.Name);
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateHeading()
        {
            ViewBag.categoryValues = new SelectList(cm.TGetList(), "CategoryID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult CreateHeading(Heading p)
        {
            Context c = new Context();
            var user = User.Identity.Name;
            var onlieusermail = c.Writers.Where(x => x.Mail == user.ToString()).FirstOrDefault();
            HeadingValidator validations = new HeadingValidator();
            ValidationResult result = validations.Validate(p);
            if (result.IsValid)
            {
                p.HeadingDate = DateTime.Now;
                p.Status = true;
                p.WriterID = onlieusermail.WriterID;
                hm.TAdd(p);
                return RedirectToAction("MyHeading");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                ViewBag.categoryValues = new SelectList(cm.TGetList(), "CategoryID", "Name");

                return View(p);
            }

        }

        public ActionResult DeleteHeading(int id)
        {

            var values = hm.TGetById(id);
            values.Status = false;
            hm.TUpdate(values);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            ViewBag.categoryValues = new SelectList(cm.TGetList(), "CategoryID", "Name");
            return View(hm.TGetById(id));
        }

        [HttpPost]
        public ActionResult UpdateHeading(Heading p)
        {
            HeadingValidator validations = new HeadingValidator();
            ValidationResult result = validations.Validate(p);
            if (result.IsValid)
            {
                var head = hm.TGetById(p.HeadingID);
                head.Name = p.Name;
                head.CategoryID = p.CategoryID;
                hm.TUpdate(head);
                return RedirectToAction("MyHeading");
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

        [HttpGet]
        public ActionResult AllHeading(int sayfaNo = 1)
        {
            return View(hm.TGetList().Where(x => x.Status == true).ToList().ToPagedList(sayfaNo, 4));
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.headname = hm.TGetById(id);
            TempData["headingid"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            var user = wm.TGetList().Where(x => x.Mail == User.Identity.Name).FirstOrDefault();
            p.ContentDate = DateTime.Now;
            p.Status = true;
            p.HeadingID = (int)TempData["headingid"];
            p.WriterID = user.WriterID;
            contentrepo.TAdd(p);
            return RedirectToAction("AllHeading");
        }



    }
}