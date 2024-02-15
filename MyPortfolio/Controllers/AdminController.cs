using MyPortfolio.Models.Data;
using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class AdminController : Controller
    {  // GET: admin
        DataContext db = new DataContext();
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {

            var login = db.Admins.Where(x => x.UserName == admin.UserName).SingleOrDefault();

            if (login.UserName == admin.UserName && login.Password == admin.Password && login.Role == admin.Role)
            {
                Session["adminid"] = login.Id;
                Session["username"] = login.UserName;
                Session["password"] = login.Password;
                Session["role"] = login.Role;           
                return RedirectToAction("Index", "Admin");

            }
            else
            {
                ViewBag.uyari = "kullanıcı adı veya şifre yanlış";
            }

            return View(admin);

        }
      
        public ActionResult Logout()
        {
            Session["adminid"] = null;
            Session["username"] = null;
            Session["password"] = null;
            Session["role"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
        }
    }
}