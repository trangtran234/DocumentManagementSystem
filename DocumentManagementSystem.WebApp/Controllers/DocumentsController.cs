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

        public List<Document> GetAllDocument()
        {
            return documentServices.GetAllDocument();
        }
    }
}
