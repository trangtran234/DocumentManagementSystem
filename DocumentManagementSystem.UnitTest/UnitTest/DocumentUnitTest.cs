using DocumentManagementSystem.Services;
using NUnit.Framework;
using Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.UnitTest.UnitTest
{
    [TestFixture]
    public class DocumentUnitTest
    {
        private IDocumentService documentService;

        [OneTimeSetUp]
        public void Init()
        {
            documentService = UnityConfig.container.Resolve<IDocumentService>();
        }

        [Test]
        public void GetLazyLoad()
        {

        }

        [OneTimeTearDown]
        public void Cleanup() { }
    }
}
