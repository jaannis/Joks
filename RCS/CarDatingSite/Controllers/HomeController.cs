using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDatingSite.Controllers
{
    using CarDatingSite.Models;
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var CatFromDb = new CatProfile();
            return View(CatFromDb);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}