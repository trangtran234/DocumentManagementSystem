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
            return context.Documents.Select(d => d).ToList();
        }

        public IList<Document> GetDocumentByContentId(Guid id)
        {
            return context.Documents.Where(d => d.DocumentContent.Id == id).ToList();
        }

        public Document GetDocumentByDocumentId(int id)
        {
            return context.Documents.Where(d => d.Id == id).First();
        }

        public IList<Document> GetDocumentByParentId(int id)
        {
            return context.Documents.Where(d => d.ParentId == id).ToList();
        }
    }
}
