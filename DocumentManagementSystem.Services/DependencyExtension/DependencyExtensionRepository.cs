using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentManagementSystem.Repository;
using Unity;
using Unity.Extension;
using Unity.Lifetime;

namespace DocumentManagementSystem.Services.DependencyExtension
{
    public class DependencyExtensionRepository : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IDocumentRepository, DocumentRepository>(new ContainerControlledLifetimeManager());
        }
    }
}
