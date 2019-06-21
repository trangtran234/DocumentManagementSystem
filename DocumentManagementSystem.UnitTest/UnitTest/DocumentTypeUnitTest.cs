using DocumentManagementSystem.IRepository;
using DocumentManagementSystem.Services;
using NSubstitute;
using NUnit.Framework;
using Unity;

namespace DocumentManagementSystem.UnitTest
{
    [TestFixture]
    public class DocumentTypeUnitTest
    {
        private IDocumentTypeService documentTypeService;
        private IDocumentTypeRepository typeRepository;

        [OneTimeSetUp]
        public void Init()
        {
            documentTypeService = UnityConfig.container.Resolve<IDocumentTypeService>();
            typeRepository = Substitute.For<IDocumentTypeRepository>();
        }

        [Test]
        public void GetAllDocumentTypes()
        {
            typeRepository.GetAllDocumentTypes().Returns(Data.documentTypes);
            documentTypeService = new DocumentTypeService(typeRepository);

            var result = documentTypeService.GetAllDocumentTypes();
            Assert.AreEqual(result.Count, 3);
        }

        [OneTimeTearDown]
        public void Cleanup() {}
    }
}
