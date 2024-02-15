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
    public class ServisesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Servises
        public ActionResult Index()
        {
            return View(db.Serviss.ToList());
        }

        [HttpGet]
        // GET: Servises/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Servis servis)
        {
            if (ModelState.IsValid)
            {
                db.Serviss.Add(servis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servis);
        }

        // GET: Servises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servis servis = db.Serviss.Find(id);
            if (servis == null)
            {
                return HttpNotFound();
            }
            return View(servis);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public ActionResult Edit(Servis servis, int? id)
        {
            var s = db.Serviss.Where(x => x.Id == id).SingleOrDefault();
            if (ModelState.IsValid)
            {
                s.Aciklama = servis.Aciklama;
                s.Baslik = servis.Baslik;
                s.Icon = servis.Icon;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servis);
        }

        // GET: Servises/Delete/5
        public ActionResult Delete(int? id)
        {
            Servis servis = db.Serviss.Find(id);
            db.Serviss.Remove(servis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
