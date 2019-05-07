using System.Web.Http;
using DocumentManagementSystem.Services;
using DocumentManagementSystem.Services.Implement;
using DocumentManagementSystem.Services.Interface;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace DocumentManagementSystem.WebApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IDocumentService, DocumentService>(new ContainerControlledLifetimeManager());
            container.AddExtension(new DependencyExtensionServices());
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}