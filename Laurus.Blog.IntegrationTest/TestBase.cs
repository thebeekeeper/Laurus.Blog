using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Laurus.Blog.Service;
using Laurus.Components;
using Laurus.Blog.Service.Impl;
using Laurus.Components.Impl;
using Laurus.Blog.Controllers;

namespace Laurus.Blog.IntegrationTest
{
    [TestClass]
    public class TestBase
    {
        [TestInitialize]
        public void TestInit()
        {
            Container = new WindsorContainer();
            Container.Register(Component.For<IBlogService>().ImplementedBy<BlogService>().LifestyleTransient());
            Container.Register(Component.For<IRepository>().ImplementedBy<NhRepository>().LifestyleTransient());
			Container.Register(Component.For<Type>().Instance(typeof(Laurus.Blog.Entity.Blog)));
			Container.Register(Component.For<HomeController>().ImplementedBy<HomeController>().LifestyleTransient());
        }

        // don't really do this
        public IWindsorContainer Container { get; private set; }
    }

	public static class EnumerableExtensions
	{
		public static bool Unique<T>(this IEnumerable<T> x, Func<T, bool> p)
		{
			return x.Count(p) == 1;
		}
	}
}
