﻿using Laurus.Blog.Service;
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
		public void Create_And_Read_Blog()
		{
            var blogService = Container.Resolve<IBlogService>();
            blogService.CreateBlog(new Service.DataContract.Blog() { Title = "this is another test blog", Id = 0 });
            Assert.IsTrue(blogService.ListBlogs().Any(b => b.Id == 0));
			var storedBlog = blogService.GetBlog(0);
			Assert.IsNotNull(storedBlog);
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
			var allEntries = blogService.GetAllEntries();
			// this will fail - there's a bug
			Assert.IsTrue(allEntries.Where(x => x.Title.Equals("asdf") && x.Content.Equals("this is a blog entry body")).Count() == 1);
			Container.Release(blogService);
        }
    }
}
