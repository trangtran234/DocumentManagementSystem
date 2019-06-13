using DocumentManagementSystem.Models.Common;
using DocumentManagementSystem.Repository;
using DocumentManagementSystem.Repository.DependencyExtension;
using DocumentManagementSystem.Repository.Interface;
using DocumentManagementSystem.Services;
using DocumentManagementSystem.Services.DependencyExtension;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace DocumentManagementSystem.UnitTest
{
    [TestFixture]
    public class DocumentHistoryUnitTest
    {
        private IDocumentService documentService;

        [OneTimeSetUp]
        public void Init()
        {
            documentService = UnityConfig.container.Resolve<IDocumentService>();
        }

        [Test]
        public void GetDocumentHistories()
        {
            var result = documentService.GetDocumentHistories(1);
            Assert.AreEqual(result.Count, 2);
        }
    }
}
