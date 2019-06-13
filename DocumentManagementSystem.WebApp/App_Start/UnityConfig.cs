using System.Web.Http;
using DocumentManagementSystem.Services.DependencyExtension;
using Unity;
using Unity.WebApi;
using DocumentManagementSystem.Repository.DependencyExtension;

namespace DocumentManagementSystem.WebApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.AddExtension(new DependencyExtensionRepository());
            container.AddExtension(new DependencyExtensionService());
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}