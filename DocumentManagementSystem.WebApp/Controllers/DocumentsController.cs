using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DocumentManagementSystem.Services.Implement;
using DocumentManagementSystem.Services.Interface;

namespace DocumentManagementSystem.WebApp.Controllers
{
    public class DocumentsController : ApiController
    {
        private IDocumentService _documentServices;
        public DocumentsController(DocumentService documentServices)
        {
            _documentServices = documentServices;
        }

        public string GetAllDocument()
        {
            return _documentServices.GetAllDocument();
        }
    }
}
