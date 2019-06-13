using DocumentManagementSystem.Repository;
using DocumentManagementSystem.UnitTest.Mockup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Extension;
using Unity.Lifetime;
using Unity;
using DocumentManagementSystem.Services;

namespace DocumentManagementSystem.UnitTest
{
    public class DependencyExtensionUnitTest : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IDocumentTypeRepository, DocumentTypeMockup>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IDocumentTypeService, DocumentTypeService>(new ContainerControlledLifetimeManager());
        }
    }
}
