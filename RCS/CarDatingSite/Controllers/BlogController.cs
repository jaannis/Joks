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

    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {

            using (var catDb = new CatDB())
            {

                //iegūt postu sarakstu no postu datubāzes tabulas
                var postListFromDb = catDb.Posts.ToList();

                //izveido skatu, tam iekšā iedodot postu sarakstu
                return View(postListFromDb);

            }
        }

        //pievienosim postu
        public ActionResult AddPost()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddPost(Blog userCreatedPost)
        {
            if (ModelState.IsValid == false)
            {
                return View("Index");
            }

            //izveidot savienojumu ar datu bāzi
            using (var catDb = new CatDB())
            {
                //pievieno kaķi kaķu tabulā
                catDb.Posts.Add(userCreatedPost);

                //saglabājam izmaiņas datubāzē
                catDb.SaveChanges();
            }

            //pavēlām browserim atgriezties index lapā
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditPost(Blog blog, HttpPostedFileBase uploadedPicture)
        {
            if (ModelState.IsValid == false)
            {
                return View(blog);
            }


            return RedirectToAction("Index");
        }


        //posta rediģēšana
        public ActionResult EditPost(int editablePostId)
        {
            using (var catDb = new CatDB())
            {
                var editablePost = catDb.Posts.First(blog => blog.PostId == editablePostId);
                return View("EditCat", editablePost);
            }
        }





        public ActionResult DeletePost(int deletablePostId)
        {
            using (var catDb = new CatDB())
            {

                //atrast postu kam pieder norādītais idenfikators
                var deleteablePost = catDb.Posts.First(blog => blog.PostId == deletablePostId);

                //izdzēst šo kaķi no tabulas
                catDb.Posts.Remove(deleteablePost);

                //saglabāt veiktās izmaiņas
                catDb.SaveChanges();

            }
            //Jāpievineo using.System.Net
            //pavēlam browserim atgriezied Index lapā (t.i pārlādē to)
            return RedirectToAction("Index");
        }

    }
}