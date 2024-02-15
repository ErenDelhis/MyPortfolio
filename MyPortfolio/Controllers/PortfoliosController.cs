using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MyPortfolio.Models;
using MyPortfolio.Models.Data;

namespace MyPortfolio.Controllers
{
    public class PortfoliosController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Portfolios
        public ActionResult Index()
        {
            return View(db.Portfolios.ToList());
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Portfolio portfolio, HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                if (ResimURL != null)
                {
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imgInfo = new FileInfo(ResimURL.FileName);

                    string imgname = Guid.NewGuid().ToString() + imgInfo.Extension;
                    img.Save("~/Fotoo/Portfoio/" + imgname);
                    img.Resize(600, 600);

                    portfolio.Foto = "/Fotoo/Portfoio/" + imgname;
                }
                db.Portfolios.Add(portfolio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(portfolio);
        }
        [HttpGet]
        // GET: Portfolios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio portfolio = db.Portfolios.Find(id);
            if (portfolio == null)
            {
                return HttpNotFound();
            }
            return View(portfolio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Portfolio portfolio, int? id, HttpPostedFileBase ResimURL)
        {
            var s = db.Portfolios.Where(x => x.Id == id).SingleOrDefault();
            if (ModelState.IsValid)
            {
                if (ResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(s.Foto)))
                    {
                        System.IO.File.Delete(Server.MapPath(s.Foto));
                    }

                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imgInfo = new FileInfo(ResimURL.FileName);

                    string imgname = Guid.NewGuid().ToString() + imgInfo.Extension;
                    img.Resize(600, 600);
                    img.Save("~/Fotoo/Portfoio/" + imgname);

                    portfolio.Foto = "/Fotoo/Portfoio/" + imgname;
                }
                s.Foto = portfolio.Foto;
                s.Tur = portfolio.Tur;
                db.SaveChanges();
                return RedirectToAction("Index");
            }



            return View(portfolio);
        }
        public ActionResult Delete(int? id)
        {
            var s = db.Portfolios.Where(x => x.Id == id).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath(s.Foto)))
            {
                System.IO.File.Delete(Server.MapPath(s.Foto));
            }
            Portfolio portfolio = db.Portfolios.Find(id);
            db.Portfolios.Remove(portfolio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Portfolios/Delete/5

    }
}
