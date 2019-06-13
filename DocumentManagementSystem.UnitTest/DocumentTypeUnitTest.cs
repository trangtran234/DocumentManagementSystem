using DocumentManagementSystem.Repository;
using DocumentManagementSystem.Services;
using DocumentManagementSystem.Services.Automapper;
using DocumentManagementSystem.WebApp.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.UnitTest
{
    [TestFixture]
    public class DocumentTypeUnitTest
    {
        private Mock<IDocumentTypeRepository> mock;
        private DocumentTypeService documentTypeService;

        [Test]
        public void GetAllDocumentTypes()
        {
            List<Models.DocumentType> documentTypes = new List<Models.DocumentType>()
            {
                new Models.DocumentType { Id = 1 , Type = "Training" },
                new Models.DocumentType { Id = 2 , Type = "Tax" }
            };
            mock = new Mock<IDocumentTypeRepository>();
            mock.Setup(m => m.GetAllDocumentTypes()).Returns(documentTypes);

            documentTypeService = new DocumentTypeService(mock.Object);
            var result = documentTypeService.GetAllDocumentTypes();
            Assert.AreEqual(result.Count, 2);
        }
    }
}
