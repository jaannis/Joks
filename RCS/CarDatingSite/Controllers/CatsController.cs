using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDatingSite.Controllers

{
    using System.Data.Entity;
    using CarDatingSite.Models;
    using System.Data.Entity.Migrations;
    using System.IO;

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
                return View(userCreatedCat);
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
        public ActionResult EditCat(CatProfile catProfile, HttpPostedFileBase uploadedPicture)
        {
            if (ModelState.IsValid == false)
            {
                return View(catProfile);
            }

            using (var catDb = new CatDB())
            {
                //izveidojam jaunu profila bildes datubāzes ekspemplāru, ko ierakstīsim datubāzē
                var profilePic = new Models.File();
                //saglabājam bildes faila nosuakumu
                profilePic.FileName = Path.GetFileName(uploadedPicture.FileName);

                //saglabājam bildes tipu
                profilePic.ContentType = uploadedPicture.ContentType;

           
                //izmantojam BynaryReader lai pārvērstu bildi baitos
                using (var reader = new BinaryReader(uploadedPicture.InputStream))
                {
                    profilePic.Content = reader.ReadBytes(uploadedPicture.ContentLength);
                }

                //pasakam profile bildei kas ir piesaistītais kaķis
                profilePic.CatProfileId = catProfile.CatId;
                profilePic.CatProfile = catProfile;

                //pievienojam profila bildes datubāzes ierakstu Files tabulai
                catDb.Files.Add(profilePic);

                //pasakam kaķu profila bildei, ka viņa ir viņa profila bilde
                catProfile.File = profilePic;

                //vajag using System.Data.Entity;
                catDb.Entry(catProfile).State = System.Data.Entity.EntityState.Modified;
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