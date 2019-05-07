using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentManagementSystem.Repository.Implement;
using DocumentManagementSystem.Repository.Interface;
using Unity;
using Unity.Extension;

namespace DocumentManagementSystem.Services
{
    public class DependencyExtensionServices : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IDocumentRepository, DocumentRepository>();
        }
    }
}
