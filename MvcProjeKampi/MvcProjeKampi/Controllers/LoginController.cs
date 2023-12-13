using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            AdminRepository ar = new AdminRepository();
            var adminuserinfo = ar.Login(p.UserName, p.Password);
            if(adminuserinfo != null && adminuserinfo.Status == true)
            {
                FormsAuthentication.SetAuthCookie(p.UserName, false);
                Session["UserName"] = p.UserName.ToString();
                return RedirectToAction("Index", "Heading");
            }
            
            else
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya şifre Hatalı!.");
                return View(p);
            }
            
        }
    
        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {

            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //Context c = new Context();
            //var user = c.Writers.Where(x => x.Mail == p.Mail && x.Password == p.Password).FirstOrDefault();
            WriterLoginManager wlm = new WriterLoginManager(new WriterRepository());
            var user = wlm.LoginByWriter(p.Mail, p.Password);
            if(user != null)
            {
                FormsAuthentication.SetAuthCookie(p.Mail, false);
                Session["Mail"] = p.Mail.ToString();
                Session.Abandon();
                return RedirectToAction("MyHeading", "WriterPanel");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı Adı veya şifre Hatalı!.");
                return View(p);
            }
        }

        public ActionResult WriterLogout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Default");
        }

    }
}