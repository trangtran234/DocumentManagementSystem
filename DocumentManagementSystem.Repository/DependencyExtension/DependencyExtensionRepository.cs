using DocumentManagementSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;
using Unity.Injection;
using Unity.Lifetime;

namespace DocumentManagementSystem.Repository.DependencyExtension
{
    public class DependencyExtensionRepository : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IDocumentContext, DocumentManagementSystemEntities>(new PerThreadLifetimeManager(), new InjectionConstructor("name=DocumentManagementSystemEntities"));
        }
    }
}