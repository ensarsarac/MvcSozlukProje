using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.EntityFramework.Repository;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new HeadingRepository());
        CategoryManager cm = new CategoryManager(new CategoryRepository());
        WriterManager wm = new WriterManager(new WriterRepository());
        [HttpGet]
        public ActionResult Index(string searchheading)
        {

            return View(hm.GetListByFilter(searchheading));          
        }


        public ActionResult HeadingReport()
        {
            return View(hm.TGetList());
        }


        [HttpGet]
        public ActionResult AddHeading()
        {
            ViewBag.categoryValues = new SelectList(cm.TGetList(), "CategoryId", "Name");
            ViewBag.writervalues = new SelectList(wm.TGetList(), "WriterId", "Mail");
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            HeadingValidator validationRules = new HeadingValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                p.Status = true;
                p.HeadingDate = DateTime.Now;
                hm.TAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                ViewBag.categoryValues = new SelectList(cm.TGetList(), "CategoryId", "Name");
                ViewBag.writervalues = new SelectList(wm.TGetList(), "WriterId", "Mail");
                return View(p);
            }
            
        }
        [HttpGet]
        public ActionResult AreYouSureDelete(int id)
        {
            return View(hm.TGetById(id));
        }
        
        public ActionResult DeleteHeading(int id)
        {
            var value = hm.TGetById(id);
            value.Status = false;
            hm.TUpdate(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            ViewBag.categoryValues = new SelectList(cm.TGetList(), "CategoryId", "Name");
            ViewBag.writervalues = new SelectList(wm.TGetList(), "WriterId", "Mail");
            return View(hm.TGetById(id));
        }
        [HttpPost]
        public ActionResult UpdateHeading(Heading p)
        {
            HeadingValidator validationRules = new HeadingValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                var value = hm.TGetById(p.HeadingID);
                value.Name = p.Name;
                value.CategoryID = p.CategoryID;
                value.WriterID = p.WriterID;
                hm.TUpdate(value);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                ViewBag.categoryValues = new SelectList(cm.TGetList(), "CategoryId", "Name");
                ViewBag.writervalues = new SelectList(wm.TGetList(), "WriterId", "Mail");
                return View(p);
            }
            
        }




    }
}