using DocumentManagementSystem.Services;
using NUnit.Framework;
using Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentManagementSystem.Models;
using DocumentManagementSystem.IRepository;

namespace DocumentManagementSystem.UnitTest.UnitTest
{
    [TestFixture]
    public class DocumentUnitTest
    {
        private IDocumentService documentService;
        private IDocumentRepository documentRepository;

        [OneTimeSetUp]
        public void Init()
        {
            documentService = UnityConfig.container.Resolve<IDocumentService>();
            documentRepository = UnityConfig.container.Resolve<IDocumentRepository>();
        }

        [TestCaseSource(typeof(Data), "lazyLoadCases")]
        public void GetLazyLoad(bool desc, int page, int pageSize, int parentId, string propertyName)
        {
            int totalRecords;
            List<Document> expected = documentRepository.LazyLoadDocuments(propertyName, desc, page, pageSize, parentId, out totalRecords);

            List<Document> documents = documentService.LazyLoadDocuments(desc, page, pageSize, parentId, propertyName, out totalRecords);
            foreach(Document document in documents)
            {
                Console.WriteLine(document.DocumentType, 
                    document.DocumentName, 
                    document.Created, 
                    document.CreatedBy.Username, 
                    document.LastModified, 
                    document.LastModifiedBy.Username);
            }
        }

        [Test]
        public void UpdateDocument()
        {
            List<Document> documents = Data.documents;
            foreach (var item in documents)
            {
                documentRepository.AddDocument(item, item.DocumentTypes.ToList());
            }

            Document document = documents.First();
            List<DocumentType> documentTypeUpdating = new List<DocumentType>
                {
                    new DocumentType{Id = 1, Type = "HR"},
                    new DocumentType{Id = 2, Type = "IT"},
                    new DocumentType{Id = 3, Type = "Admin"}
                };
            document.DocumentTypes.Clear();
            foreach (var item in documentTypeUpdating)
            {
                document.DocumentTypes.Add(item);
            }

            documentService.UpdateDocument(document);
            Document actualDocument = documentService.GetDocumentByDocumentId(document.Id);
            Assert.AreEqual(actualDocument.DocumentTypes.Count, documentTypeUpdating.Count);
        }

        [OneTimeTearDown]
        public void Cleanup() { }
    }
}
