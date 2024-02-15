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
    public class IletisimsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Iletisims
        public ActionResult Index()
        {
            return View(db.Iletisims.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Iletisim iletisim)
        {
            if (ModelState.IsValid)
            {
                db.Iletisims.Add(iletisim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iletisim);
        }
       
        // GET: Iletisims/Delete/5
        public ActionResult Delete(int? id)
        {
            Iletisim iletisim = db.Iletisims.Find(id);
            db.Iletisims.Remove(iletisim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
