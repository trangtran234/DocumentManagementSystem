using DocumentManagementSystem.Models;
using DocumentManagementSystem.Models.Common;
using DocumentManagementSystem.Repository;
using DocumentManagementSystem.Repository.DependencyExtension;
using DocumentManagementSystem.Repository.Interface;
using DocumentManagementSystem.Services;
using DocumentManagementSystem.Services.Automapper;
using DocumentManagementSystem.Services.DependencyExtension;
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
            List<Models.DocumentHistory> documentHistoriesRepo = new List<Models.DocumentHistory>()
            {
                new Models.DocumentHistory { Id = 1, DocumentId = 1, Document = new Models.Document { Id = 1,  DocumentName = "Test", DocumentType = "docx"}, Date = DateTime.Now, UserId = 1, ActionEvent = Helper.HistoryAction.Upload },
                new Models.DocumentHistory { Id = 2, DocumentId = 1, Document = new Models.Document { Id = 1,  DocumentName = "Test", DocumentType = "docx"}, Date = DateTime.Now, UserId = 1, ActionEvent = Helper.HistoryAction.Edit }
            };

            var mockDocumentRepo = new Mock<IDocumentRepository>();
            var mockDocumentHistoryRepo = new Mock<IDocumentHistoryRepository>();

            mockDocumentHistoryRepo.Setup(m => m.GetDocumentHistories(documentHistoryId)).Returns(documentHistoriesRepo);

            var documentService = new DocumentService(mockDocumentRepo.Object, mockDocumentHistoryRepo.Object);

            var actualResult = documentService.GetDocumentHistories(documentHistoryId);
            
            Assert.AreNotEqual(actualResult.Count, 2);
        }
    }
}
