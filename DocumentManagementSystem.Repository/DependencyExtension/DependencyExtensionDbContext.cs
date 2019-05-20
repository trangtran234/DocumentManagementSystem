using DocumentManagementSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Extension;
using Unity.Injection;

namespace DocumentManagementSystem.Repository.DependencyExtension
{
    public class DependencyExtensionDbContext : UnityContainerExtension
    {
        protected override void Initialize()
        {
            //Container.RegisterType<IDocumentContext, DocumentManagementSystemEntities>(new PerRequestLifetimeManager(),
            //    new InjectionConstructor("name=DocumentManagementSystemEntities"));
        }
    }
}
