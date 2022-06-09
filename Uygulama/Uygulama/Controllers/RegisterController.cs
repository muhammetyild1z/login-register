using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uygulama.Models;

namespace Uygulama.Controllers
{
    public class RegisterController : Controller
    {
        
        kullanicilarEntities1 db = new kullanicilarEntities1();
        // GET: Register
        [AllowAnonymous]
        public ActionResult register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult register(FormCollection form)
        {           
            uygulama model = new uygulama();
            model.Ad = form["Ad"].Trim();
            model.Mail = form["mail"].Trim();
            model.Sifre = form["password"].Trim();
            model.Sehir = form["il"].Trim();
           model.YETKİ = "B";
            var count = db.uygulama.Where(x=>x.Mail==model.Mail).Count();
            if (count>0)
            {
                ViewBag.hata = "Bu e-posta daha önce kaydedilmiştir.";
                return View();
            }
            if (form["password"]==form["passwordR"])
            {
                db.uygulama.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.sifre = "Şifreler uyuşmuyor";
                return View();
            }
        }
    }
}