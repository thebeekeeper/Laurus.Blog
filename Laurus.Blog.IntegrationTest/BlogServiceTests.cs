using Laurus.Blog.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laurus.Components.Impl;
using Laurus.Components;

namespace Laurus.Blog.IntegrationTest
{
    [TestClass]
    public class BlogServiceTests : TestBase
    {
        [TestMethod]
        public void Create_Should_Save_Blog()
        {
            var blogService = Container.Resolve<IBlogService>();
            var id = blogService.CreateBlog(new Service.DataContract.Blog() { Title = "test blog" });
            Assert.IsTrue(blogService.ListBlogs().Any(b => b.Id == id));
            Container.Release(blogService);
        }

		[TestMethod]
		public void Create_And_Read_Blog()
		{
            var blogService = Container.Resolve<IBlogService>();
            var id = blogService.CreateBlog(new Service.DataContract.Blog() { Title = "this is another test blog" });
            Assert.IsTrue(blogService.ListBlogs().Any(b => b.Id == id));
			var storedBlog = blogService.GetBlog(id);
			Assert.IsNotNull(storedBlog);
            Container.Release(blogService);
		}

        [TestMethod]
        public void Create_Entry_Should_Save()
        {
            var blogService = Container.Resolve<IBlogService>();
			var blog = new Service.DataContract.Blog() { Title = "test blog", Id = -1 };
            blogService.CreateBlog(blog);
			var entry = new Service.DataContract.Entry() { Title = "asdf", Content = "this is a blog entry body" };
			blogService.AddEntry(-1, entry);
			var entries = blogService.GetEntriesForBlog(blog.Id);
			Container.Release(blogService);
        }

		[TestMethod]
		public void nontest()
		{
			var t = typeof(Entity.Blog);
			IRepository x = new NhRepository(t);
			var blog = new Entity.Blog()
			{
				Title = "adsf",
				Entries = new List<Entity.Entry>() { new Entity.Entry() { Name = "asdf", Content = "blah blah blah" } }
			};
			x.Persist(blog);
		}
    }
}
