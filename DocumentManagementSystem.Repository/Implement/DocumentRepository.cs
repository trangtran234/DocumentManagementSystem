using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DocumentManagementSystem.Models;
namespace DocumentManagementSystem.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private DocumentManagementSystemEntities context = new DocumentManagementSystemEntities();

        public IList<Document> GetAllDocuments()
        {
            IList<Document> documents = context.Documents.Select(d => d).ToList();
            return documents;
        }

        public IList<Document> GetDocumentByContentId(Guid id)
        {
            IList<Document> documents = context.Documents.Where(d => d.DocumentContent.Id == id).ToList();
            return documents;
        }

        public Document GetDocumentByDocumentId(int id)
        {
            Document document = context.Documents.Where(d => d.Id == id).First();
            return document;
        }

        public IList<Document> GetDocumentByDocumentType(string type)
        {
            IList<Document> documents = context.Documents.Where(d => d.DocumentType == type).ToList();
            return documents;
        }

        public IList<Document> GetDocumentByParentId(int id)
        {
            IList<Document> documents = context.Documents.Where(d => d.ParentId == id).ToList();
            return documents;
        }
    }
}
