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
            return documentServices.GetAllDocument();
        }

        public IList<Document> GetDocumentsByContentId(int id)
        {
            return documentServices.GetDocumentByContentId(id);
        }

        public IList<Document> GetDocumentByParentId(int id)
        {
            return documentServices.GetDocumentByParentId(id);
        }

        public Document GetDocumentByDocumentId(int id)
        {
            return documentServices.GetDocumentByDocumentId(id);
        }
    }
}
