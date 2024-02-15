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
    public class IlgialanisController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Ilgialanis
        public ActionResult Index()
        {
            return View(db.Ilgi.ToList());
        }

        [HttpGet]
        // GET: Ilgialanis/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]

        public ActionResult Create(Ilgialani ilgialani)
        {
            if (ModelState.IsValid)
            {
                db.Ilgi.Add(ilgialani);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ilgialani);
        }

        // GET: Ilgialanis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ilgialani ilgialani = db.Ilgi.Find(id);
            if (ilgialani == null)
            {
                return HttpNotFound();
            }
            return View(ilgialani);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(Ilgialani ilgialani, int? id)
        {
            var s = db.Ilgi.Where(x => x.Id == id).SingleOrDefault();

            if (ModelState.IsValid)
            {
                s.Classadi = ilgialani.Classadi;
                s.Ilgiadi = ilgialani.Ilgiadi;
                s.Renkkodu = ilgialani.Renkkodu;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ilgialani);
        }

        // GET: Ilgialanis/Delete/5
        public ActionResult Delete(int? id)
        {
            Ilgialani ilgialani = db.Ilgi.Find(id);
            db.Ilgi.Remove(ilgialani);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
