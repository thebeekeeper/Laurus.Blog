using Laurus.Blog.Models;
using Laurus.Blog.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laurus.Blog.Controllers
{
    [Authorize]
    public class CreateController : Controller
    {
        public CreateController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEntry(EntryModel model)
        {
            _blogService.AddEntry(1, new Service.DataContract.Entry()
            {
                Title = model.Title,
                Content = model.Content,
                OwnerDisplayName = this.User.Identity.Name,
                Created = DateTime.Now
            });
            return Redirect("/Entries");
        }

        private IBlogService _blogService;
    }
}
