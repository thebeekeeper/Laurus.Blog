using Laurus.Blog.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Blog.IntegrationTest
{
    [TestClass]
    public class BlogServiceTests : TestBase
    {
        [TestMethod]
        public void Create_Should_Save_Blog()
        {
            var blogService = Container.Resolve<IBlogService>();
            blogService.CreateBlog(new Service.DataContract.Blog() { Title = "test blog", Id = 0 });
            Assert.IsTrue(blogService.ListBlogs().Any(b => b.Id == 0));
            Container.Release(blogService);
        }

        [TestMethod]
        public void Create_Entry_Should_Save()
        {
            var blogService = Container.Resolve<IBlogService>();
			var blog = new Service.DataContract.Blog() { Title = "test blog", Id = 0 };
            blogService.CreateBlog(blog);
			var entry = new Service.DataContract.Entry() { Title = "asdf", Content = "this is a blog entry body" };
			blogService.AddEntry(blog, entry);
        }
    }
}
