using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocumentManagementSystem.Services;
using DocumentManagementSystem.Services.Automapper;
using Unity;
using Unity.Extension;
using Unity.Lifetime;

namespace DocumentManagementSystem.WebApp.DependencyExtension
{
    public class DependencyExtensionServices : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IDocumentService, DocumentService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IDocumentTypeService, DocumentTypeService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IAutoMapperConfig, AutoMapperConfig>(new ContainerControlledLifetimeManager());
        }
    }
}