using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Laurus.Blog.App_Start;
using Laurus.Blog.Controllers;
using Laurus.Blog.Service;
using Laurus.Blog.Service.Impl;
using Laurus.Components;
using Laurus.Components.Impl;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Laurus.Blog
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            IWindsorContainer container = new WindsorContainer();
            container.Register(AllTypes.FromThisAssembly().BasedOn(typeof(Controller)).LifestyleTransient());
            container.Register(Component.For<IBlogService>().ImplementedBy<BlogService>());
			container.Register(Component.For<IRepository>().ImplementedBy<NhRepository>().LifestylePerWebRequest());
			container.Register(Component.For<Type>().Instance(typeof(Laurus.Blog.Entity.Blog)));
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
        }
    }

    public class WindsorControllerFactory : DefaultControllerFactory
    {
        public WindsorControllerFactory(IWindsorContainer container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return _container.Resolve(controllerType) as IController;
        }

        private IWindsorContainer _container;
    }
}