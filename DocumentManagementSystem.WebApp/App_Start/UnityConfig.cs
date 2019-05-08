using System.Web.Http;
using DocumentManagementSystem.Services.DependencyExtension;
using DocumentManagementSystem.WebApp.DependencyExtension;
using Unity;
using Unity.WebApi;

namespace DocumentManagementSystem.WebApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.AddExtension(new DependencyExtensionRepository());
            container.AddExtension(new DependencyExtensionServices());           
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}