using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentManagementSystem.Services.Automapper;
using Unity.Lifetime;
using Unity;
using Unity.Extension;
using Unity.Injection;

namespace DocumentManagementSystem.Services.DependencyExtension
{
    public class DependencyExtensionAutoMapper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IAutoMapperConfig, AutoMapperConfig>(new ContainerControlledLifetimeManager());
        }
    }
}
