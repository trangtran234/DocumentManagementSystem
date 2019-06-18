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
            List<Document> expectedDocument = documentRepository.LazyLoadDocuments(propertyName, desc, page, pageSize, parentId, out totalRecords);
            List<Document> documents = documentService.LazyLoadDocuments(desc, page, pageSize, parentId, propertyName, out totalRecords);
            if(expectedDocument.Count != documents.Count)
            {
                Assert.Fail();
            }
            for(int i =0; i < expectedDocument.Count; i++)
            {
                Assert.AreEqual(expectedDocument[i], documents[i]);
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

        [Test]
        public void GetAllDocument()
        {
            List<Document> documents = Data.documents;
            foreach (var item in documents)
            {
                documentRepository.AddDocument(item, item.DocumentTypes.ToList());
            }

            List<Document> actualDocuments = documentService.GetAllDocument();
            Assert.AreEqual(actualDocuments.Count, documents.Count);
        }

        [Test]
        public void GetDocumentByParentId()
        {
            int parentId = 1;
            List<Document> documents = Data.documents;
            foreach (var item in documents)
            {
                documentRepository.AddDocument(item, item.DocumentTypes.ToList());
            }

            List<Document> actualDocuments = documentService.GetDocumentByParentId(parentId);
            Assert.Greater(actualDocuments.Count, 0);
        }

        [Test]
        public void GetFolders()
        {
            List<Document> documents = Data.documents;
            foreach (var item in documents)
            {
                documentRepository.AddDocument(item, item.DocumentTypes.ToList());
            }

            List<DocumentTreeView> documentsTree = documentService.GetFolders();
            Assert.Greater(documentsTree.Count, 0);
        }

        [Test]
        public void GetFoldersByFolderId()
        {
            int parentId = 1;
            List<Document> documents = Data.documents;
            foreach (var item in documents)
            {
                documentRepository.AddDocument(item, item.DocumentTypes.ToList());
            }

            List<DocumentTreeView> documentsTree = documentService.GetFoldersByFolderId(parentId);
            Assert.Greater(documentsTree.Count, 0);
        }

        [Test]
        public void GetFileStructure()
        {
            List<Document> documents = Data.documents;
            foreach (var item in documents)
            {
                documentRepository.AddDocument(item, item.DocumentTypes.ToList());
            }

            List<DocumentTreeView> folderStructured = documentService.GetFileStructure();
            Assert.Greater(folderStructured.Count, 0);
        }

        [OneTimeTearDown]
        public void Cleanup() { }
    }
}
