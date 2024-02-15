using MyPortfolio.Models;
using MyPortfolio.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult About()
        {
            return PartialView(db.Abouts.ToList());
        }
        public PartialViewResult Services()
        {
            return PartialView(db.Serviss.ToList());
        }
        public PartialViewResult Bilgii()
        {
            return PartialView(db.Bilgi.ToList());
        }
        public PartialViewResult Ilgialanii()
        {
            return PartialView(db.Ilgi.ToList());
        }

        public PartialViewResult Portfolio()
        {
            return PartialView(db.Portfolios.ToList());
        }
        [HttpGet]
        public ActionResult Yonlendir()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yonlendir(Iletisim iletisim)
        {
            if (ModelState.IsValid)
            {
                db.Iletisims.Add(iletisim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}