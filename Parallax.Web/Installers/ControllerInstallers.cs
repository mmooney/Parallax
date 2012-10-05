using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Raven.Client;
using Parallax.DataAccess;
using Parallax.Data.Base;
using System.Web.Security;
using System.Web;

namespace Parallax.Web.Installers
{
	public class ControllerInstallers : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Classes.FromThisAssembly()
								.BasedOn<IController>()
								.LifestyleTransient());
			container.Register(Classes.FromAssemblyNamed("Parallax.DataAccess").BasedOn<object>().LifestylePerWebRequest());

			container.Register(Component.For<IDocumentStore>()
									.UsingFactoryMethod(() => DataHelper.GetDocumentStore())
									.LifeStyle.Singleton);

			container.Register(Component.For<IDocumentSession>()
									.UsingFactoryMethod(() => container.Kernel.Resolve<IDocumentStore>().OpenSession())
									.LifeStyle.PerWebRequest);

			container.Register(Component.For<ParallaxSession>()
									.UsingFactoryMethod(()=>new ParallaxSession(GetCurrentUser()))
									.LifeStyle.PerWebRequest);
		}

		private ParallaxUser GetCurrentUser()
		{
			ParallaxUser user;
			if(HttpContext.Current != null && HttpContext.Current.User != null && HttpContext.Current.User.Identity != null && HttpContext.Current.User.Identity.IsAuthenticated)
			{
				user = new ParallaxUser
				{
					UserName = HttpContext.Current.User.Identity.Name
				};
			}
			else 
			{
				user = null;
			}
			return user;
		}
	}
}