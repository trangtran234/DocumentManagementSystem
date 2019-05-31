using DocumentManagementSystem.Models;
using DocumentManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DocumentManagementSystem.WebApp.Controllers
{
    [RoutePrefix("api/documenttypes")]
    public class DocumentTypesController : ApiController
    {
        private IDocumentTypeService documentTypeService;

        public DocumentTypesController(DocumentTypeService documentTypeService)
        {
            this.documentTypeService = documentTypeService;
        }

        [Route("DocumentTypes")]
        [HttpGet]
        public List<DocumentType> GetAllDocumentTypes()
        {
            return documentTypeService.GetAllDocumentTypes();
        }
    }
}
