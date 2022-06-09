using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Uygulama.Models;

namespace Uygulama.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        
        // GET: Login
        kullanicilarEntities1 db = new kullanicilarEntities1();
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(uygulama mdl)
        {
            var model = db.uygulama.FirstOrDefault(x=>x.Mail==mdl.Mail&&x.Sifre==mdl.Sifre);
            if (model!=null)
            {
                
                FormsAuthentication.SetAuthCookie(mdl.Mail, false);
               
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.hata = "Kullanıcı adı veya şifre hatalı..";
                return View();
            }           
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("login");
        }


    }
}