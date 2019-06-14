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
            document.DocumentTypes = types;
            documents.Add(document);
            return true;
        }

        public bool AddDocumentContent(DocumentContent documentContent)
        {
            contents.Add(documentContent);
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
            throw new NotImplementedException();
        }

        public Document GetDocumentByDocumentId(int id)
        {
            var document = documents.Where(d => d.Id == id).FirstOrDefault();
            return document;
        }

        public List<Document> GetDocumentByParentId(int id)
        {
            throw new NotImplementedException();
        }

        public List<DocumentTreeView> GetFolders()
        {
            throw new NotImplementedException();
        }

        public List<DocumentTreeView> GetFoldersByFolderId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Document> LazyLoadDocuments(string propertyName, bool desc, int page, int pageSize, int parentId, out int totalRecords)
        {
            var documents = Data.documents.Where(d => d.ParentId.Equals(null));
            if(parentId != 0)
            {
                documents = Data.documents.Where(d => d.ParentId == parentId);
            }
            totalRecords = documents.Count();

            int skipRows = page * pageSize;
            if (desc)
            {
                documents = documents.OrderBy(propertyName + " desc").Skip(skipRows).Take(pageSize);
            }
            else
            {
                documents = documents.OrderBy(propertyName + " asc").Skip(skipRows).Take(pageSize);
            }
            return documents.ToList();
        }

        public bool UpdateDocument(Document document)
        {
            var documentUpdating = documents.Where(d => d.Id == document.Id).FirstOrDefault();
            documentUpdating.LastModified = document.LastModified;
            documentUpdating.LastModifiedBy.Id = Helper.FAKE_USERID;
            documentUpdating.DocumentTypes.Clear();
            foreach(var item in document.DocumentTypes)
            {
                documentUpdating.DocumentTypes.Add(item);
            }

            documents.Remove(documents.Where(d => d.Id == document.Id).First());
            documents.Add(documentUpdating);

            return true;
        }
    }
}
