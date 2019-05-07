﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocumentManagementSystem.Services.Implement;
using DocumentManagementSystem.Services.Interface;
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
        }
    }
}