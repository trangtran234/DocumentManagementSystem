using System.Web.Http;
using DocumentManagementSystem.Services.DependencyExtension;
using DocumentManagementSystem.WebApp.DependencyExtension;
using Unity;
using Unity.WebApi;
using DocumentManagementSystem.Repository;
using Unity.Injection;
using Unity.Lifetime;
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