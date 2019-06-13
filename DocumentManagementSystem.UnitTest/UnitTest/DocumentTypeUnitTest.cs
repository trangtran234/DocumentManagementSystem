using DocumentManagementSystem.Services;
using NUnit.Framework;
using Unity;

namespace DocumentManagementSystem.UnitTest
{
    [TestFixture]
    public class DocumentTypeUnitTest
    {
        private IDocumentTypeService documentTypeService;

        [OneTimeSetUp]
        public void Init()
        {
            documentTypeService = UnityConfig.container.Resolve<IDocumentTypeService>();
        }

        [Test]
        public void GetAllDocumentTypes()
        {
            var result = documentTypeService.GetAllDocumentTypes();
            Assert.AreEqual(result.Count, 3);
        }

        [OneTimeTearDown]
        public void Cleanup() {}
    }
}
