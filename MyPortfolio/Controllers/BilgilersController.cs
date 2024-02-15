using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyPortfolio.Models;
using MyPortfolio.Models.Data;

namespace MyPortfolio.Controllers
{
    public class BilgilersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Bilgilers
        public ActionResult Index()
        {
            return View(db.Bilgi.ToList());
        }

        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public ActionResult Create(Bilgiler bilgiler)
        {
            if (ModelState.IsValid)
            {
                db.Bilgi.Add(bilgiler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bilgiler);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilgiler bilgiler = db.Bilgi.Find(id);
            if (bilgiler == null)
            {
                return HttpNotFound();
            }
            return View(bilgiler);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Bilgiler bilgiler, int? id)
        {
            var s = db.Bilgi.Where(x => x.Id == id).SingleOrDefault();
            if (ModelState.IsValid)
            {
                s.Tel = bilgiler.Tel;
                s.Mail = bilgiler.Mail;
                s.Adres = bilgiler.Adres;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bilgiler);
        }

        public ActionResult Delete(int? id)
        {
            Bilgiler bilgiler = db.Bilgi.Find(id);
            db.Bilgi.Remove(bilgiler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
