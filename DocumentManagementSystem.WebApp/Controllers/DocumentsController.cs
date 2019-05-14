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
        public IList<Document> GetFolders()
        {
            IList<Document> documents = documentServices.GetFolders();
            return documents;
        }

        [Route("FolderByFolderId/{id:int}")]
        [HttpGet]
        public IList<Document> GetFoldersByFolderId(int id)
        {
            IList<Document> documents = documentServices.GetFoldersByFolderId(id);
            return documents;
        }

        [Route("documentDTO")]
        [HttpGet]
        public IList<DocumentDTO> GetDocumentDTO()
        {
            List<DocumentDTO> documentDTOs = new List<DocumentDTO>()
            {
                new DocumentDTO
                {
                    Id = 1,
                    Description = "Document Description",
                    FileType = "folder",
                    Created = "2019-05-15",
                    LastModified = "2019-05-15"
                },
                new DocumentDTO
                {
                    Id = 2,
                    Description = "Docx Description",
                    FileType = "docx",
                    Created = "2019-05-15",
                    LastModified = "2019-05-15"
                }
            };
            return documentDTOs;
        }

        [Route("documentDTO")]
        [HttpPost]
        public void GetDocumentDTO(DocumentDTO document)
        {
            List<DocumentDTO> documentDTOs = new List<DocumentDTO>();
            documentDTOs.Add(document);
            foreach(var item in documentDTOs)
            {
                Console.WriteLine("Add document from angular to API: {0}", item.Description);
            }
            
        }
    }
}
