using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDatingSite.Controllers

{
    using CarDatingSite.Models;
    using System.Data.Entity.Migrations;

    public class CatsController : Controller
    {
        // GET: Cats
        public ActionResult Index()
        {
            
            using (var catDb = new CatDB())
            {
                
                //iegūt kaķu sarakstu no kaķu datubāzes tabulas
                var catListFromDb = catDb.CatProfiles.ToList();

                //izveido skatu, tam iekšā iedodot kaķu sarakstu
                return View(catListFromDb);

            }
        }

        //pievienosim kaķi
        public ActionResult AddCat()
        {

             return View();
        }

        [HttpPost]
        public ActionResult AddCat(CatProfile userCreatedCat)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction("Index");
            }

            //izveidot savienojumu ar datu bāzi
            using (var catDb = new CatDB())
            {
                //pievieno kaķi kaķu tabulā
                catDb.CatProfiles.Add(userCreatedCat);

                //saglabājam izmaiņas datubāzē
                catDb.SaveChanges();
            }

            //pavēlām browserim atgriezties index lapā
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditCat(CatProfile catProfile)
        {
            using (var catDb = new CatDB())
            {

                catDb.Entry(catProfile).CurrentValues.SetValues(catProfile);
                catDb.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        //kaķa rediģēšana
        public ActionResult EditCat(int editableCatId)
        {
            using (var catDb = new CatDB())
            {
                var editableCat = catDb.CatProfiles.First(catProfile => catProfile.CatId == editableCatId);
                return View("EditCat",editableCat);
            }
        }


        


        public ActionResult DeleteCats(int deletableCatId)
        {
            using (var catDb = new CatDB())
            {

                //atrast kaķi kam pieder norādītais idenfikators
                var deleteableCat = catDb.CatProfiles.First(catProfile => catProfile.CatId == deletableCatId);

                //idzēst šo kaķi no tabulas
                catDb.CatProfiles.Remove(deleteableCat);

                //saglabāt veiktās izmaiņas
                catDb.SaveChanges();

            }
            //Jāpievineo using.System.Net
            //pavēlam browserim atgriezied Index lapā (t.i pārlādē to)
            return RedirectToAction("Index");
        }

    }
}