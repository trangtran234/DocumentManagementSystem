using DocumentManagementSystem.IRepository;
using DocumentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using DocumentManagementSystem.Models.Common;

namespace DocumentManagementSystem.UnitTest.Mockup
{
    public class DocumentMockup : IDocumentRepository
    {
        private List<Document> documents = new List<Document>();
        private List<DocumentContent> contents = new List<DocumentContent>();

        public bool AddDocument(Document document, List<DocumentType> types)
        {
            //document.DocumentTypes = types;
            //DocumentContent content = new DocumentContent
            //{
            //    Id = document.DocumentContentId,
            //    Content = document.DocumentContent
            //};

            //contents.Add(content);
            documents.Add(document);
            return true;
        }

        public void DeleteDocument(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteDocumentContent(Guid id)
        {
            throw new NotImplementedException();
        }

        public Guid FindDocumentContent(int id)
        {
            throw new NotImplementedException();
        }

        public List<Document> GetAllDocuments()
        {
            List<Document> documentsMockup = documents;
            return documentsMockup;
        }

        public Document GetDocumentByDocumentId(int id)
        {
            var document = documents.Where(d => d.Id == id).FirstOrDefault();
            return document;
        }

        public List<Document> GetDocumentByParentId(int id)
        {
            List<Document> documentsById = documents.Where(d => d.ParentId == id).ToList();
            return documentsById;
        }

        public List<DocumentTreeView> GetFolders()
        {
            List<Document> documentsMockup = documents.Where(d => d.DocumentType == Helper.DocumentType.folder.ToString()).ToList();

            List<DocumentTreeView> documentsTree = new List<DocumentTreeView>();
            foreach(var item in documentsMockup)
            {
                DocumentTreeView documentTree = new DocumentTreeView
                {
                    Id = item.Id,
                    DocumentName = item.DocumentName,
                    ParentId = item.ParentId
                };
                documentsTree.Add(documentTree);
            }

            return documentsTree;
        }

        public List<DocumentTreeView> GetFoldersByFolderId(int id)
        {
            List<Document> documentsMockup = documents.Where(d => d.ParentId == id && d.DocumentType == Helper.DocumentType.folder.ToString()).ToList();
            DocumentTreeView documentTree = new DocumentTreeView();
            List<DocumentTreeView> documentsTree = new List<DocumentTreeView>();
            foreach (var item in documentsMockup)
            {
                documentTree.Id = item.Id;
                documentTree.DocumentName = item.DocumentName;
                documentTree.ParentId = item.ParentId;
                documentsTree.Add(documentTree);
            }

            return documentsTree;
        }

        public bool UpdateDocument(Document document)
        {
            var documentUpdating = documents.Where(d => d.Id == document.Id).FirstOrDefault();
            documentUpdating.LastModified = document.LastModified;
            documentUpdating.LastModifiedBy.Id = Helper.FAKE_USERID;

            documents.Remove(documents.Where(d => d.Id == document.Id).First());
            int lengh = documents.Count;
            documents.Add(documentUpdating);
            if (documents.Count > lengh)
            {
                return true;
            }
            return false;
        }
    }
}
