using System.Web.Http;
using DocumentManagementSystem.Services.DependencyExtension;
using DocumentManagementSystem.WebApp.DependencyExtension;
using Unity;
using Unity.WebApi;

using DocumentManagementSystem.Repository.Interface;
using DocumentManagementSystem.Repository;
using Unity.Injection;
using Unity.Lifetime;

namespace DocumentManagementSystem.WebApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.AddExtension(new DependencyExtensionRepository());
            container.AddExtension(new DependencyExtensionServices());
            container.RegisterType<IDocumentContext, DocumentManagementSystemEntities>(new PerThreadLifetimeManager(), new InjectionConstructor("name=DocumentManagementSystemEntities"));
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}