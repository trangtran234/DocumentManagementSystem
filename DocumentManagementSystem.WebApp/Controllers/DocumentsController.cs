using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DocumentManagementSystem.Models;
using DocumentManagementSystem.Services;

namespace DocumentManagementSystem.WebApp.Controllers
{
    public class DocumentsController : ApiController
    {
        private IDocumentService documentServices;
        public DocumentsController(DocumentService documentServices)
        {
            this.documentServices = documentServices;
        }

        public IList<Document> GetAllDocument()
        {
            IList<Document> documents = documentServices.GetAllDocument();
            return documents;
        }

        public IList<Document> GetDocumentsByContentId(Guid id)
        {
            IList<Document> documents = documentServices.GetDocumentByContentId(id);
            return documents;
        }

        public IList<Document> GetDocumentByParentId(int id)
        {
            IList<Document> documents = documentServices.GetDocumentByParentId(id);
            return documents;
        }

        public Document GetDocumentByDocumentId(int id)
        {
            Document document = documentServices.GetDocumentByDocumentId(id);
            return document;
        }

        public IList<Document> GetDocumentByDocumentType(string type)
        {
            IList<Document> documents = documentServices.GetDocumentByDocumentType(type);
            return documents;
        }
    }
}
