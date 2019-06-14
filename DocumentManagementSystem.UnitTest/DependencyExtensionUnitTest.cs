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
using DocumentManagementSystem.IRepository;
using DocumentManagementSystem.Services.Interface;
using DocumentManagementSystem.Services.Implement;

namespace DocumentManagementSystem.UnitTest
{
    public class DependencyExtensionUnitTest : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IDocumentTypeRepository, DocumentTypeMockup>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IDocumentTypeService, DocumentTypeService>(new ContainerControlledLifetimeManager());

            Container.RegisterType<IDocumentRepository, UploadDocumentMockup>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IUploadService, UploadService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IDocumentService, DocumentService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IDocumentRepository, DocumentMockup>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IDocumentHistoryRepository, DocumentHistoryMockup>(new ContainerControlledLifetimeManager());
        }
    }
}
