using Laurus.Blog.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laurus.Blog.Controllers
{
    public class CategoryController : BlogBaseController
    {
        public CategoryController(IBlogService blogService)
            : base(blogService)
        {
            _blogService = blogService;
        }

        public ActionResult Index(int id)
        {
            var title = _blogService.GetBlog(id).Title;
            ViewBag.Message = title;
            var entries = from e in _blogService.GetEntriesForBlog(id)
                          select new Models.EntryModel()
                          {
                              Id = e.Id,
                              Created = e.Created.ToShortDateString(),
                              Content = e.Content,
                              Title = e.Title
                          };
            return View(entries);
        }

        private IBlogService _blogService;
    }
}
