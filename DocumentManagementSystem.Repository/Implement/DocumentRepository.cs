using DocumentManagementSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DocumentManagementSystem.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private IDocumentContext context;

        public DocumentRepository(IDocumentContext context)
        {
            this.context = context;
        }

        public IList<Document> GetDocumentByParentId(int id)
        {
            var documents = context.Documents.Where(d => d.ParentId == id).ToList();
            return documents;
        }

        public IList<Document> GetAllDocuments()
        {
            IList<Document> documents = context.Documents.Select(d => d).ToList();
            return documents;
        }

        public Document GetDocumentByDocumentId(int id)
        {
            Document document = context.Documents.Include("DocumentTags").FirstOrDefault<Document>(d => d.Id == id);
            return document;
        }

        public IList<Document> GetFolders()
        {
            const string folderType = "folder";
            const int id = -1;
            IList<Document> documents = context.Documents.Where(d => d.DocumentType == folderType && d.ParentId == id).ToList();
            return documents;
        }

        public IList<Document> GetFoldersByFolderId(int id)
        {
            const string folderType = "folder";
            IList<Document> documents = context.Documents.Where(d => d.ParentId == id && d.DocumentType == folderType).ToList();
            return documents;
        }

        public void AddListDocument(List<Document> listDocuments)
        {
            foreach (Document document in listDocuments)
            {
                context.Documents.Add(document);
                
            }

            context.SaveChanges();
        }

        public void AddDocumentContent(List<DocumentContent> listContents)
        {
            foreach(DocumentContent content in listContents)
            {
                context.DocumentContents.Add(content);
            }
            context.SaveChanges();
        }
    }
}
