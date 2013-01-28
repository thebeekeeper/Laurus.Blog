using Laurus.Blog.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laurus.Blog.Controllers
{
    public class HomeController : BlogBaseController
    {
        private IBlogService _blogService;
        public HomeController(IBlogService blogService) : base(blogService)
        {
            _blogService = blogService;
        }

        public ActionResult Index()
        {
            var entries = from e in _blogService.GetEntriesForBlog(1).ToList()
                          select new Models.EntryModel()
                          {
                              Id = e.Id,
                              Title = e.Title,
                              Content = e.Content,
                          };
            return View(entries);
        }

        public ViewResult Details(int id)
        {
            var entry = _blogService.GetEntry(id);
            var model = new Models.EntryModel()
            {
                Id = entry.Id,
                Title = entry.Title,
                Content = entry.Content,
                Created = entry.Created.ToShortDateString()
            };
            return View(model);
        }

        //public ViewResult Index()
        //{
        //    if (this.User.Identity.IsAuthenticated)
        //    {
        //        ViewBag.Message = String.Format("logged in as {0}", this.User.Identity.Name);
        //    }
        //    //show blogs
        //    var allBlogs = _blogService.ListBlogs();
        //    return View(allBlogs);
        //}

        //public ViewResult Details(int id)
        //{
        //    var entries = _blogService.GetEntriesForBlog(id);
        //    return View(entries);
        //}

        public ActionResult Create()
        {
            _blogService.CreateBlog(new Service.DataContract.Blog()
            {
                Title = "blogs are dumb",
                Id = 0
            });
            return View();
        } 

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
