using DocumentManagementSystem.IRepository;
using DocumentManagementSystem.Models.Common;
using DocumentManagementSystem.Services;
using DocumentManagementSystem.UnitTest.Mockup;
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
        private IDocumentHistoryRepository documentHistoryMockup;

        [OneTimeSetUp]
        public void Init()
        {
            documentHistoryMockup = UnityConfig.container.Resolve<IDocumentHistoryRepository>();
            documentService = UnityConfig.container.Resolve<IDocumentService>();
        }

        [Test]
        public void GetDocumentHistories_WhenAddingDocument()
        {
            int documentId = 1;
            string documentName = "Test";
            string documentType = Helper.DocumentType.docx.ToString();

            Models.Document document = new Models.Document()
            {
                Id = documentId,
                DocumentName = documentName,
                DocumentType = documentType
            };
            documentHistoryMockup.AddDocumentHistory(document, Helper.HistoryAction.Upload);

            var result = documentService.GetDocumentHistories(documentId);
            Assert.AreNotEqual(result.Count, 0);
            var action = result.Where(d => d.DocumentId == documentId && d.ActionEvent == Helper.HistoryAction.Upload).FirstOrDefault();
            Assert.AreNotEqual(action, null);
        }

        [Test]
        public void GetDocumentHistories_WhenEditingDocument()
        {
            int documentId = 1;
            string documentName = "TestEdit";
            string documentType = Helper.DocumentType.docx.ToString();

            Models.Document document = new Models.Document()
            {
                Id = documentId,
                DocumentName = documentName,
                DocumentType = documentType
            };

            var result = documentService.GetDocumentHistories(documentId);
            var actionsEdit = result.Where(d => d.DocumentId == documentId && d.ActionEvent == Helper.HistoryAction.Edit).ToList();
            var actionEditLengh = actionsEdit.Count;

            documentHistoryMockup.AddDocumentHistory(document, Helper.HistoryAction.Edit);
            result = documentService.GetDocumentHistories(documentId);
            actionsEdit = result.Where(d => d.DocumentId == documentId && d.ActionEvent == Helper.HistoryAction.Edit).ToList();
            Assert.Greater(actionsEdit.Count, actionEditLengh);
        }

        [Test]
        public void GetDocumentHistories_WhenEditingMoreThanOne()
        {
            int documentId = 1;
            string documentName = "TestEdit";
            string documentType = Helper.DocumentType.docx.ToString();

            Models.Document document = new Models.Document()
            {
                Id = documentId,
                DocumentName = documentName,
                DocumentType = documentType
            };

            var result = documentService.GetDocumentHistories(documentId);
            var actionsEdit = result.Where(d => d.DocumentId == documentId && d.ActionEvent == Helper.HistoryAction.Edit).ToList();
            var actionEditLengh = actionsEdit.Count;

            for (int i = 0; i <= 5; i++)
            {
                documentHistoryMockup.AddDocumentHistory(document, Helper.HistoryAction.Edit);
                result = documentService.GetDocumentHistories(documentId);
                actionsEdit = result.Where(d => d.DocumentId == documentId && d.ActionEvent == Helper.HistoryAction.Edit).ToList();
                Assert.Greater(actionsEdit.Count, actionEditLengh);
                actionEditLengh = actionsEdit.Count;
            }
        }
    }
}
