﻿using DocumentManagementSystem.Repository.DependencyExtension;
using DocumentManagementSystem.Services.DependencyExtension;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using Unity;

namespace DocumentManagementSystem.UnitTest
{
    [SetUpFixture]
    public static class UnityConfig
    {
        public static IUnityContainer container = new UnityContainer();
        [OneTimeSetUp]
        public static void RegisterComponents()
        {
            //container.AddExtension(new DependencyExtensionRepository());
            //container.AddExtension(new DependencyExtensionService());
            container.AddExtension(new DependencyExtensionUnitTest());
        }
    }
}