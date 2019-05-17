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
    [RoutePrefix("api/documents")]
    public class DocumentsController : ApiController
    {
        private IDocumentService documentServices;
        public DocumentsController(DocumentService documentServices)
        {
            this.documentServices = documentServices;
        }

        [Route("DocumentByFolderId/{id:int}")]
        [HttpGet]
        public IList<Document> GetDocumentByParentId(int id)
        {
            IList<Document> documents = documentServices.GetDocumentByParentId(id);
            return documents;
        }

        [Route("DocumentById/{id:int}")]
        [HttpGet]
        public Document GetDocumentByDocumentId(int id)
        {
            Document document = documentServices.GetDocumentByDocumentId(id);
            return document;
        }

        [Route("Folders")]
        [HttpGet]
        public IList<DocumentTreeViewDTO> GetFolders()
        {
            IList<DocumentTreeViewDTO> documents = documentServices.GetFolders();
            return documents;
        }

        [Route("FolderByFolderId/{id:int}")]
        [HttpGet]
        public IList<DocumentTreeViewDTO> GetFoldersByFolderId(int id)
        {
            IList<DocumentTreeViewDTO> documents = documentServices.GetFoldersByFolderId(id);
            return documents;
        }
    }
}
