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

        [OneTimeSetUp]
        public void Init()
        {
            documentService = UnityConfig.container.Resolve<IDocumentService>();
        }

        [Test]
        public void GetDocumentHistories()
        {
            int documentId = 1;
            string documentName = "Test";
            string documentType = Helper.DocumentType.docx.ToString();

            Models.Document document = new Models.Document()
            {
                Id = documentId, DocumentName = documentName, DocumentType = documentType
            };

            DocumentHistoryMockup historyMockup = new DocumentHistoryMockup();
            historyMockup.AddDocumentHistory(document, Helper.HistoryAction.Upload);
            historyMockup.AddDocumentHistory(document, Helper.HistoryAction.Edit);

            var result = documentService.GetDocumentHistories(documentId);
            Assert.AreEqual(result.Count, 2);
        }
    }
}
