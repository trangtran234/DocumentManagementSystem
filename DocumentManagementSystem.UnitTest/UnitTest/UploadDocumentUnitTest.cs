using DocumentManagementSystem.Services.Interface;
using NUnit.Framework;
using Unity;

namespace DocumentManagementSystem.UnitTest.UnitTest
{
    [TestFixture]
    public class UploadDocumentUnitTest
    {
        private IUploadService uploadService;

        [OneTimeSetUp]
        public void Init()
        {
            uploadService = UnityConfig.container.Resolve<IUploadService>();
        }

        [Test]
        public void AddDocument()
        {
            
        }

        [OneTimeTearDown]
        public void Cleanup() { }
    }
}
