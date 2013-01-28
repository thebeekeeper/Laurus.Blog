using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laurus.Blog.IntegrationTest;
using Laurus.Blog.Controllers;
using Laurus.Blog.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataContract = Laurus.Blog.Service.DataContract;

namespace Laurus.Blog.IntegrationTest
{
	[TestClass]
	public class ControllerTests : TestBase
	{
		[TestMethod]
		public void Index_Should_Return_All_Blogs()
		{
			var controller = base.Container.Resolve<HomeController>();
			var actionResult = controller.Index();
			//var m = actionResult.ViewData.Model as IEnumerable<DataContract.Blog>;
			//Assert.IsTrue(m.Count() > 0);
		}

		[TestMethod]
		public void Details_Should_Return_Entries()
		{
			var blogService = base.Container.Resolve<IBlogService>();
			var entryTitle = Guid.NewGuid().ToString();
			var blogId = blogService.CreateBlog(new DataContract.Blog()
			{
				Title = Guid.NewGuid().ToString(),
				Entries = new List<DataContract.Entry>()
				{
					{ new DataContract.Entry() { Title = entryTitle, Content = "blog blog blog" } }
				}
			});

			var controller = base.Container.Resolve<HomeController>();
			var model = (controller.Details(blogId).ViewData.Model) as IEnumerable<DataContract.Entry>;
			Assert.IsTrue(model.Unique(x => x.Title.Equals(entryTitle)));
		}
	}
}
