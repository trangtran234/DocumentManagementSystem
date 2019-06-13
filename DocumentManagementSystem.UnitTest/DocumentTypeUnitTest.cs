using DocumentManagementSystem.Repository;
using DocumentManagementSystem.Services;
using DocumentManagementSystem.UnitTest.Mockup;
using NUnit.Framework;
using Unity;
using Unity.Lifetime;

namespace DocumentManagementSystem.UnitTest
{
    [TestFixture]
    public class DocumentTypeUnitTest
    {
        private IDocumentTypeService documentTypeService;

        private IUnityContainer unityContainer; 

        [OneTimeSetUp]
        public void Init()
        {
            unityContainer.AddExtension(new DependencyExtensionUnitTest());
            documentTypeService = unityContainer.Resolve<IDocumentTypeService>();

        }

        [Test]
        public void GetAllDocumentTypes()
        {
            var result = documentTypeService.GetAllDocumentTypes();
            Assert.AreEqual(result.Count, 3);
        }

        [Test]
        public void GetDocumentType()
        {
            var result = documentTypeService.GetAllDocumentTypes();
            Assert.AreEqual(result.Count, 3);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {

        }
    }
}
