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

        public void GetTreeView(List<DocumentTreeViewDTO> list, DocumentTreeViewDTO current, ref List<DocumentTreeViewDTO> returnList)
        {
            var childs = list.Where(c => c.ParentId == current.Id).ToList();
            current.Childrens = new List<DocumentTreeViewDTO>();
            current.Childrens.AddRange(childs);
            foreach(var item in childs)
            {
                GetTreeView(list, item, ref returnList);
            }
        }

        public List<DocumentTreeViewDTO> BuildTree(List<DocumentTreeViewDTO> list)
        {
            List<DocumentTreeViewDTO> returnList = new List<DocumentTreeViewDTO>();
            var topLevels = list.Where(a => a.ParentId == -1);
            returnList.AddRange(topLevels);
            foreach (var item in topLevels)
            {
                GetTreeView(list, item, ref returnList);
            }

            return returnList;
        }

        [Route("FolderStructure")]
        [HttpGet]
        public IList<DocumentTreeViewDTO> GetFileStructure()
        {
            List<DocumentTreeViewDTO> list = documentServices.GetFolders();

            List<DocumentTreeViewDTO> treelist = new List<DocumentTreeViewDTO>();
            if (list.Count() > 0)
            {
                treelist = BuildTree(list);
            }
            return treelist;
        }
    }
}
