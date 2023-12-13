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
    [Authorize(Roles ="A")]
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new CategoryRepository());
        [HttpGet]
        public ActionResult Index()
        {
            return View(cm.TGetList()); 
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult result = validationRules.Validate(p);

            if (result.IsValid)
            {
                p.Status = true;
                cm.TAdd(p);
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

        public ActionResult DeleteCategory(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = cm.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category p)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult result = validationRules.Validate(p);

            if (result.IsValid)
            {
                var value = cm.TGetById(p.CategoryID);
                value.Name = p.Name;
                value.Aciklama = p.Aciklama;
                cm.TUpdate(value);
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