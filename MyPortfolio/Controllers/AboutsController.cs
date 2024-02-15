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
    public class AboutsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Hakkimdas
        public ActionResult Index()
        {
            return View(db.Abouts.ToList());
        }

        [HttpGet]

        // GET: Hakkimdas/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(About about, HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                if (ResimURL != null)
                {
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imgInfo = new FileInfo(ResimURL.FileName);

                    string imgname = Guid.NewGuid().ToString() + imgInfo.Extension;
                    img.Resize(600, 600);
                    img.Save("~/Fotoo/About/" + imgname);
                    about.Foto = "/Fotoo/About/" + imgname;
                }
                db.Abouts.Add(about);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(about);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            About hakkimda = db.Abouts.Find(id);
            if (hakkimda == null)
            {
                return HttpNotFound();
            }
            return View(hakkimda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(About about, HttpPostedFileBase ResimURL, int? id)
        {
            var s = db.Abouts.Where(x => x.Id == id).SingleOrDefault();
            if (ModelState.IsValid)
            {

                //if (Request.Files.Count > 0 && Request.Files[0] != null && Request.Files[0].ContentLength > 0)
                //{
                //    string dosyaAdi = "Fotoo" + Guid.NewGuid().ToString() + Path.GetExtension(Request.Files[0].FileName);
                //    string yol = Path.Combine(Server.MapPath("~/Fotoo/About/"), dosyaAdi);
                //    Request.Files[0].SaveAs(yol);

                //    hakkimda.Foto = "/Fotoo/About/" + dosyaAdi;
                //}
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
                    img.Save("~/Fotoo/About/" + imgname);

                    about.Foto = "/Fotoo/About/" + imgname;
                }


                s.FreeLance = about.FreeLance;
                s.Foto = about.Foto;
                s.Mail = about.Mail;
                s.Sehir = about.Sehir;
                s.Tel = about.Tel;
                s.HakkimdaYazisi = about.HakkimdaYazisi;
                s.DogumGunu = about.DogumGunu;
                s.Baslik = about.Baslik;
                s.Derece = about.Derece;
                s.Yas = about.Yas;
                s.Rutbe = about.Rutbe;


                db.SaveChanges();
                return View(about);
            }

            return View(about);
        }

        // GET: Hakkimdas/Delete/5
        public ActionResult Delete(int? id)
        {
            var s = db.Abouts.Where(x => x.Id == id).SingleOrDefault();

            if (System.IO.File.Exists(Server.MapPath(s.Foto)))
            {
                System.IO.File.Delete(Server.MapPath(s.Foto));
            }
            About hakkimda = db.Abouts.Find(id);
            db.Abouts.Remove(hakkimda);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
