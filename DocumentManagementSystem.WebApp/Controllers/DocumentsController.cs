using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
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

        private void GetTreeView(List<DocumentTreeView> list, DocumentTreeView current, ref List<DocumentTreeView> returnList)
        {
            var childs = list.Where(c => c.ParentId == current.Id).ToList();
            current.Childrens = new List<DocumentTreeView>();
            current.Childrens.AddRange(childs);
            foreach(var item in childs)
            {
                GetTreeView(list, item, ref returnList);
            }
        }

        private List<DocumentTreeView> BuildTree(List<DocumentTreeView> list)
        {
            List<DocumentTreeView> returnList = new List<DocumentTreeView>();
            var topLevels = list.Where(a => a.ParentId == 0);
            returnList.AddRange(topLevels);
            foreach (var item in topLevels)
            {
                GetTreeView(list, item, ref returnList);
            }

            return returnList;
        }

        [Route("FolderStructure")]
        [HttpGet]
        public IList<DocumentTreeView> GetFileStructure()
        {
            List<DocumentTreeView> list = documentServices.GetFolders();

            List<DocumentTreeView> treelist = new List<DocumentTreeView>();
            if (list.Count() > 0)
            {
                treelist = BuildTree(list);
            }
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

        [Route("LazyLoadDocuments/{desc:bool}/{page:int}/{pageSize:int}/{parentId:int}")]
        [HttpGet]
        public HttpResponseMessage LazyLoadDocuments(bool desc, int page, int pageSize, int parentId)
        {
            int totalRecords;

            List<Document> documents = documentServices.LazyLoadDocuments(desc, page, pageSize, parentId, out totalRecords);
            Console.WriteLine("Lenght: " + totalRecords);

            var json = new JavaScriptSerializer().Serialize(new
            {
                documents ,
                totalRecords
            });

            return Request.CreateResponse(HttpStatusCode.OK, json);
        }
    }
}
