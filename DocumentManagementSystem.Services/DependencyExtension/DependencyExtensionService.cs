﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentManagementSystem.Repository;
using DocumentManagementSystem.Services.Automapper;
using Unity;
using Unity.Extension;
using Unity.Lifetime;

namespace DocumentManagementSystem.Services.DependencyExtension
{
    public class DependencyExtensionService : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IDocumentRepository, DocumentRepository>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IDocumentTermRepository, DocumentTermRepository>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IAutoMapperConfig, AutoMapperConfig>(new ContainerControlledLifetimeManager());
        }
    }
}