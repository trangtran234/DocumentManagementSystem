using DocumentManagementSystem.IRepository;
using DocumentManagementSystem.Models;
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

        private void GetDocumentHistories_WhenAddingDocument(Document document)
        {
            documentHistoryMockup.AddDocumentHistory(document, Helper.HistoryAction.Upload);

            var result = documentService.GetDocumentHistories(document.Id);
            var action = result.Where(d => d.DocumentId == document.Id && d.ActionEvent == Helper.HistoryAction.Upload).FirstOrDefault();
            Assert.AreNotEqual(action, null);
        }

        [Test]
        public void GetDocumentHistories_WhenAddingOneDocument()
        {
            Document document = new Document()
            {
                Id = 1,
                DocumentName = "TestAdding",
                DocumentType = Helper.DocumentType.docx.ToString()
            };

            GetDocumentHistories_WhenAddingDocument(document);
        }

        [TestCaseSource(typeof(Data), "documentsAddingForTestDocumentHistory")]
        public void GetDocumentHistories_WhenAddingOneMoreDocument(Document document)
        {
            GetDocumentHistories_WhenAddingDocument(document);
        }

        private void GetDocumentHistories_WhenEditingDocument(Document document)
        {
            var result = documentService.GetDocumentHistories(document.Id);
            var actionsEdit = result.Where(d => d.DocumentId == document.Id && d.ActionEvent == Helper.HistoryAction.Edit).ToList();
            var actionEditLengh = actionsEdit.Count;

            documentHistoryMockup.AddDocumentHistory(document, Helper.HistoryAction.Edit);
            result = documentService.GetDocumentHistories(document.Id);
            actionsEdit = result.Where(d => d.DocumentId == document.Id && d.ActionEvent == Helper.HistoryAction.Edit).ToList();
            Assert.Greater(actionsEdit.Count, actionEditLengh);
            actionEditLengh = actionsEdit.Count;
        }

        [Test]
        public void GetDocumentHistories_WhenEditingOneTime()
        {
            Document document = new Document()
            {
                Id = 1,
                DocumentName = "TestEditing",
                DocumentType = Helper.DocumentType.docx.ToString()
            };

            GetDocumentHistories_WhenEditingDocument(document);
        }

        [TestCaseSource(typeof(Data), "documentsEditingForTestDocumentHistory")]
        public void GetDocumentHistories_WhenEditingMoreThanOneTime(Document document)
        {
            GetDocumentHistories_WhenEditingDocument(document);
        }
    }
}
