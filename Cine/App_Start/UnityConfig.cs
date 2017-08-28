using Cine.Repository;
using Cine.Service;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace Cine
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            container.RegisterType<IEntradasRepository, EntradasRepository>();
            container.RegisterType<IEntradasService, EntradasService>();
            container.RegisterType<IPeliculasRepository, PeliculasRepository>();
            container.RegisterType<IPeliculasService, PeliculasService>();
        }
    }
}