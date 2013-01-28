using Laurus.Blog.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laurus.Blog.Controllers
{
    public class EntriesController : Controller
    {
        public EntriesController(IBlogService blogService)
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
                Content = entry.Content
            };
            return View(model);
        }

        private IBlogService _blogService;
    }
}
