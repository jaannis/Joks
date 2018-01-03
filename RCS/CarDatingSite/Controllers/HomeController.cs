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
            //izveido kaķi
            var CatFromDb = new CatProfile();
            CatFromDb.CatName = "Reinis";
            CatFromDb.CatAge = 15;
            CatFromDb.CatImage = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4d/Cat_March_2010-1.jpg/800px-Cat_March_2010-1.jpg";

          
            //izveido citu kaķi
            var anotherCatFromDb = new CatProfile();
            anotherCatFromDb.CatName = "Cits Reinis";
            anotherCatFromDb.CatAge = 5;
            anotherCatFromDb.CatImage = "https://www.petmd.com/sites/default/files/what-does-it-mean-when-cat-wags-tail.jpg";

            using (var catDb = new CatDB())
            {
                //pievieno kaķi kaķu sarakstam
                catDb.CatProfiles.Add(CatFromDb);
                catDb.CatProfiles.Add(anotherCatFromDb);

                //saglabā datubāzē veiktās izmaiņas
                catDb.SaveChanges();

                //iegūt kaķu sarakstu no kaķu datubāzes tabulas
                var catListFromDb = catDb.CatProfiles.ToList();

                //izveido skatu, tam iekšā iedodot kaķu sarakstu
                return View(catListFromDb);
            }

            
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