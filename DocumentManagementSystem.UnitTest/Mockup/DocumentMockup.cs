using DocumentManagementSystem.IRepository;
using DocumentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.UnitTest.Mockup
{
    public class DocumentMockup : IDocumentRepository
    {
        private List<Document> documents = new List<Document>();
        private List<DocumentContent> contents = new List<DocumentContent>();

        public bool AddDocument(Document document, List<DocumentType> types)
        {
            document.DocumentTypes = types;
            documents.Add(document);
            return true;
        }

        public bool AddDocumentContent(DocumentContent documentContent)
        {
            contents.Add(documentContent);
            return true;
        }

        public void DeleteDocument(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteDocumentContent(Guid id)
        {
            throw new NotImplementedException();
        }

        public Guid FindDocumentContent(int id)
        {
            throw new NotImplementedException();
        }

        public List<Document> GetAllDocuments()
        {
            throw new NotImplementedException();
        }

        public Document GetDocumentByDocumentId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Document> GetDocumentByParentId(int id)
        {
            throw new NotImplementedException();
        }

        public List<DocumentTreeView> GetFolders()
        {
            throw new NotImplementedException();
        }

        public List<DocumentTreeView> GetFoldersByFolderId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Document> LazyLoadDocuments(string propertyName, bool desc, int page, int pageSize, int parentId, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDocument(Document document)
        {
            throw new NotImplementedException();
        }
    }
}
