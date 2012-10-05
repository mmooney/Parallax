using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Raven.Client;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using RavenDBMembership.Web.Infrastructure;
using System.Reflection;
using Parallax.DataAccess;
using Microsoft.Practices.ServiceLocation;
using Castle.Windsor.Installer;

namespace Parallax.Web
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		private static IWindsorContainer Container { get; set; }

		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);

		}

		private static void BootstrapContainer()
		{
			MvcApplication.Container = new WindsorContainer().Install(FromAssembly.This());
			var controllerFactory = new WindsorControllerFactory(MvcApplication.Container.Kernel);
			ControllerBuilder.Current.SetControllerFactory(controllerFactory);
		}

		protected void Application_Start()
		{
			MvcApplication.BootstrapContainer();
			//Container = new WindsorContainer();

			//// Common Service Locator
			//ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(Container));

			//// RavenDB embedded
			//Container.Register(Component
			//    .For<IDocumentStore>()
			//    .UsingFactoryMethod(() => DataHelper.GetDocumentStore())
			//    .LifeStyle.Singleton);

			//// MVC components
			//ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(Container));
			//Container.Register(AllTypes
			//    .FromAssembly(Assembly.GetExecutingAssembly())
			//    .BasedOn<IController>()
			//    .LifestyleTransient()
			//    //.Configure(c => c.LifeStyle.Transient)
			//);

			AreaRegistration.RegisterAllAreas();

			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
		}

		protected void Application_End()
		{
			//var documentStore = Container.Resolve<IDocumentStore>();
			//documentStore.Dispose();
			Container.Dispose();
		}

	}
}