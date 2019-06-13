using DocumentManagementSystem.Services.Implement;
using DocumentManagementSystem.Services.Interface;
using Unity;
using Unity.Extension;
using Unity.Lifetime;

namespace DocumentManagementSystem.Services.DependencyExtension
{
    public class DependencyExtensionService : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IDocumentService, DocumentService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IDocumentTypeService, DocumentTypeService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IUploadService, UploadService>(new ContainerControlledLifetimeManager());
        }
    }
}
