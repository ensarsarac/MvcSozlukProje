using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            
            var values = c.Admins.Where(x=>x.Role != "A").ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            c.Admins.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ChangeRole(int id)
        {
            return View(c.Admins.Find(id));
        }

        [HttpPost]
        public ActionResult ChangeRole(Admin p)
        {
            var admin = c.Admins.Find(p.ID);
            admin.UserName = p.UserName;
            admin.Password = p.Password;
            admin.Role = p.Role;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ChangeStatus(int id)
        {
            var admin = c.Admins.Find(id);
            admin.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ChangeStatus2(int id)
        {
            var admin = c.Admins.Find(id);
            admin.Status = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}