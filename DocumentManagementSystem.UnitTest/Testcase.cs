using DocumentManagementSystem.Models;
using DocumentManagementSystem.Models.Common;
using DocumentManagementSystem.Repository;
using DocumentManagementSystem.Repository.DependencyExtension;
using DocumentManagementSystem.Repository.Interface;
using DocumentManagementSystem.Services;
using DocumentManagementSystem.Services.Automapper;
using DocumentManagementSystem.Services.DependencyExtension;
using DocumentManagementSystem.UnitTest.DIConfig;
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
    public class Testcase
    {
        [Test]
        public void GetDocumentHistories()
        {
            int documentHistoryId = 1;
            List<Repository.DocumentHistory> documentHistoriesRepo = new List<Repository.DocumentHistory>()
            {
                new Repository.DocumentHistory { Id = 1, DocumentId = 1, Document = new Repository.Document { Id = 1,  DocumentName = "Test", DocumentType = "docx"}, Date = DateTime.Now, UserId = 1, ActionId = 1 },
                new Repository.DocumentHistory { Id = 2, DocumentId = 1, Document = new Repository.Document { Id = 1,  DocumentName = "Test", DocumentType = "docx"}, Date = DateTime.Now, UserId = 1, ActionId = 2 }
            };

            var mockDocumentRepo = new Mock<IDocumentRepository>();
            var mockDocumentHistoryRepo = new Mock<IDocumentHistoryRepository>();
            var mockAutomapper = new Mock<IAutoMapperConfig>();

            mockDocumentHistoryRepo.Setup(m => m.GetDocumentHistories(documentHistoryId)).Returns(documentHistoriesRepo);

            var documentService = new DocumentService(mockDocumentRepo.Object, mockAutomapper.Object, mockDocumentHistoryRepo.Object);

            var actualResult = documentService.GetDocumentHistories(documentHistoryId);
            
            Assert.AreNotEqual(actualResult.Count, 2);
        }
    }
}
