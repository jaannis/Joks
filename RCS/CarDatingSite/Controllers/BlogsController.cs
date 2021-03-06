﻿using System;
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
    using System.Net.Mail;
    using System.Net;
    using Microsoft.AspNet.Identity;

    [Authorize]
    public class BlogsController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {

            using (var catDb = new CatDB())
            {

                //iegūt postu sarakstu no postu datubāzes tabulas
                var blogListFromDb = catDb.Blogs.ToList();

                var listOfBlogsForIndex = new List<BlogsForIndex>();

                foreach(var dbBlog in blogListFromDb)
                {
                    var blogForIndex = new BlogsForIndex();
                    blogForIndex.BlogName = dbBlog.BlogName;
                    blogForIndex.BlogCreated = dbBlog.BlogCreated;
                    blogForIndex.BlogTitle = dbBlog.BlogTitle;
                    blogForIndex.BlogText = dbBlog.BlogText;
                    blogForIndex.BlogImage = dbBlog.BlogImage;
                    blogForIndex.BlogId = dbBlog.BlogId;
                    blogForIndex.BlogModified = dbBlog.BlogModified;


                    using (var usersDb = new ApplicationDbContext())
                    {
                        var user = usersDb.Users.First(record => record.Id == dbBlog.BlogCreatorID);

                        blogForIndex.BlogCreatorEmail = user.Email;
                    }

                    listOfBlogsForIndex.Add(blogForIndex);
                }
                
                //izveido skatu, tam iekšā iedodot postu sarakstu
                return View(listOfBlogsForIndex);

            }
        }

        //pievienosim postu
        public ActionResult AddBlog()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddBlog(Blog userCreatedBlog)
        {
            if (ModelState.IsValid == false)
            {
                return View("Index");
            }

            if (User.Identity.IsAuthenticated)
            {
                string userId = User.Identity.GetUserId();
                userCreatedBlog.BlogCreatorID = userId;
            }

            userCreatedBlog.BlogCreated = DateTime.Now;
            userCreatedBlog.BlogModified = DateTime.Now;

            //izveidot savienojumu ar datu bāzi
            using (var catDb = new CatDB())
            {
                //pievieno kaķi kaķu tabulā
                catDb.Blogs.Add(userCreatedBlog);

                //saglabājam izmaiņas datubāzē
                catDb.SaveChanges();
            }

           

            //pavēlām browserim atgriezties index lapā
            return RedirectToAction("Index");
        }


        //posta rediģēšana
        [HttpPost]
        public ActionResult EditBlog (Blog Blog)
        {
            if (ModelState.IsValid == false)
            {
                return View(Blog);
            }

            Blog.BlogModified = DateTime.Now;

            using (var catDb = new CatDB())
            {
                catDb.Entry(Blog).State = EntityState.Modified;
                catDb.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        public ActionResult EditBlog(int editableBlogId)
        {
            using (var catDb = new CatDB())
            {
                var editableBlog = catDb.Blogs.First(blog => blog.BlogId == editableBlogId);
                return View("EditBlog", editableBlog);
            }

        }





        public ActionResult DeleteBlog(int deletableBlogId)
        {
            using (var catDb = new CatDB())
            {

                //atrast postu kam pieder norādītais idenfikators
                var deleteableBlog = catDb.Blogs.First(blog => blog.BlogId == deletableBlogId);

                //izdzēst šo kaķi no tabulas
                catDb.Blogs.Remove(deleteableBlog);

                //saglabāt veiktās izmaiņas
                catDb.SaveChanges();

            }
            //Jāpievineo using.System.Net
            //pavēlam browserim atgriezied Index lapā (t.i pārlādē to)
            return RedirectToAction("Index");
        }

        
        
    }
}