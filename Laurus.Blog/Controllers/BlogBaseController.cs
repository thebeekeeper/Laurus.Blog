using Laurus.Blog.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laurus.Blog.Controllers
{
    public class BlogBaseController : Controller
    {
        public BlogBaseController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public ActionResult _Sidebar()
        {
            var blogs = _blogService.ListBlogs();
            var links = from b in blogs
                        select new Models.SidebarLink()
                        {
                            DisplayText = b.Title,
                            CategoryId = b.Id
                        };
            var model = new Models.Sidebar()
            {
                Title = "blargs",
                TagLine = "...",
                Links = links.ToList()
            };
            return View(model);
        }

        private IBlogService _blogService;
    }
}
