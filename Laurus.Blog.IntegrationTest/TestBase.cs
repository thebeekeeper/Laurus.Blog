using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Laurus.Blog.Service;
using Laurus.Components;
using Laurus.Blog.Service.Impl;
using Laurus.Components.Impl;

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
        }

        // don't really do this
        public IWindsorContainer Container { get; private set; }
    }
}
