using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using DocumentManagementSystem.Models;
using DocumentManagementSystem.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

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
        public IList<DocumentTreeView> GetFolders()
        {
            IList<DocumentTreeView> documents = documentServices.GetFolders();
            return documents;
        }

        [Route("FolderByFolderId/{id:int}")]
        [HttpGet]
        public IList<DocumentTreeView> GetFoldersByFolderId(int id)
        {
            IList<DocumentTreeView> documents = documentServices.GetFoldersByFolderId(id);
            return documents;
        }

        [Route("FolderStructure")]
        [HttpGet]
        public List<DocumentTreeView> GetFileStructure()
        {
            List<DocumentTreeView> treelist = documentServices.GetFileStructure();
            return treelist;
        }

        [Route("UpdateDocument")]
        [HttpPost]
        public HttpResponseMessage EditDocument(Document document)
        {
            bool isOk = documentServices.UpdateDocument(document);
            if (isOk)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [Route("LazyLoadDocuments")]
        [HttpGet]
        public HttpResponseMessage LazyLoadDocuments(int page, int pageSize, int parentId, bool desc, string propertyName)
        {
            int totalRecords;

            List<Document> documents = documentServices.LazyLoadDocuments(desc, page, pageSize, parentId, propertyName, out totalRecords);

            return Request.CreateResponse(HttpStatusCode.OK, new
            {
                documents,
                totalRecords
            });
        }

        [Route("DocumentHistories/{documentId:int}")]
        [HttpGet]
        public List<DocumentHistory> GetDocumentHistories(int documentId)
        {
            List<DocumentHistory> documentHistories = documentServices.GetDocumentHistories(documentId);
            return documentHistories;
        }
    }
}
