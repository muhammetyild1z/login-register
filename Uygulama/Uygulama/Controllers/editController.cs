using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Uygulama.Models;
using System.Web.Security;

namespace Uygulama.Controllers
{

    public class editController : Controller
    {
        kullanicilarEntities1 db = new kullanicilarEntities1();
        // GET: edit


       
        public ActionResult List()
        {
            return View(db.uygulama.ToList());
        }

        [Authorize(Roles = "A")]
        public ActionResult edit(int id)
        {
            uygulama model = new uygulama();
            model=db.uygulama.Find(id);
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "A")]
        public ActionResult edit(uygulama model)
        {
            uygulama edt = db.uygulama.Find(model.ID);
            edt.Mail = model.Mail;
            edt.Sehir = model.Sehir;
            edt.Sifre = model.Sifre;
            edt.YETKİ = model.YETKİ;
            edt.Ad = model.Ad;
            db.SaveChanges();
            return RedirectToAction("List","edit");
        }
        [Authorize(Roles = "A")]
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "A")]
        public ActionResult create(FormCollection frm)
        {
            uygulama model = new uygulama();
            model.Ad = frm["first_name1"].Trim();
            model.Mail = frm["mail"].Trim();
            model.Sehir = frm["sehir"].Trim();
            model.Sifre = frm["sifre"].Trim();
            model.YETKİ = frm["yetki"].Trim();
            var count = db.uygulama.Where(x=>x.Mail==model.Mail).Count();
            if (count>0)
            {
                ViewBag.hata = "Böyle bir e-posta sisteme kayıtlı";
            }
            else
            {
                db.uygulama.Add(model);
                db.SaveChanges();
            }
            return View();
        }
        [Authorize(Roles = "A")]
        public ActionResult delete(int id)
        {
            var sil = db.uygulama.Find(id);
            db.uygulama.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("List");
        }


    }
}