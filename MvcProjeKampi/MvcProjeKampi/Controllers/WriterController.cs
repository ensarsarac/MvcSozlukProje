using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
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
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new WriterRepository());
        public ActionResult Index()
        {
            return View(wm.TGetList()); ;
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                p.Password = "1";
                p.Image = "resim1.jpg";
                wm.TAdd(p);
                return RedirectToAction("Index");
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
        public ActionResult UpdateWriter(int id)
        {
            return View(wm.TGetById(id));
        }

        [HttpPost]
        public ActionResult UpdateWriter(Writer p)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                var user = wm.TGetById(p.WriterID);
                user.Name = p.Name;
                user.Surname = p.Surname;
                user.Mail = p.Mail;
                user.Password = p.Password;
                user.About = p.About;
                user.Image = p.Image;
                user.Title = p.Title;
                wm.TUpdate(user);
                return RedirectToAction("Index");
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


    }
}