using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using DocumentManagementSystem.Models.Common;
using DocumentManagementSystem.Repository.Interface;
using DocumentManagementSystem.Repository.Automapper;
using AutoMapper;

namespace DocumentManagementSystem.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private DocumentManagementSystemEntities context;
        private readonly IDocumentHistoryRepository historyRepository;
        private IMapper mapper;

        public DocumentRepository(DocumentManagementSystemEntities context, IDocumentHistoryRepository historyRepository, IAutoMapperConfig mapper)
        {
            this.context = context;
            this.historyRepository = historyRepository;
            this.mapper = mapper.GetMapper();
        }

        public List<Models.Document> GetDocumentByParentId(int id)
        {
            var documentsRepo = context.Documents.Where(d => d.ParentId == id).ToList();
            List<Models.Document> documents = mapper.Map<List<Models.Document>>(documentsRepo);
            return documents;
        }

        public List<Models.Document> GetAllDocuments()
        {
            List<Document> documentsRepo = context.Documents.Select(d => d).ToList();
            List<Models.Document> documents = mapper.Map<List<Models.Document>>(documentsRepo);
            return documents;
        }

        public Models.Document GetDocumentByDocumentId(int id)
        {
            Document documentRepo = context.Documents.Include("DocumentTags").FirstOrDefault<Document>(d => d.Id == id);
            Models.Document document = mapper.Map<Models.Document>(documentRepo);
            return document;
        }

        public List<Models.DocumentTreeView> GetFolders()
        {
            List<Document> documentsRepo = context.Documents.Where(d => d.DocumentType == Helper.DocumentType.folder.ToString()).ToList();
            List<Models.DocumentTreeView> documents = mapper.Map<List<Models.DocumentTreeView>>(documentsRepo);
            return documents;
        }

        public List<Models.DocumentTreeView> GetFoldersByFolderId(int id)
        {
            List<Document> documentsRepo = context.Documents.Where(d => d.ParentId == id && d.DocumentType == Helper.DocumentType.folder.ToString()).ToList();
            List<Models.DocumentTreeView> documents = mapper.Map<List<Models.DocumentTreeView>>(documentsRepo);
            return documents;
        }

        public List<Document> GetDocumentsTop(int top)
        {
            List<Document> documents = context.Documents.Select(d => d).OrderByDescending(f => f.Id).Take(top).ToList();
            return documents;
        }

        public void DeleteDocument(int id)
        {
            var document = context.Documents.SingleOrDefault(d => d.Id == id);
            context.Documents.Remove(document);
            context.SaveChanges();
        }

        public void DeleteDocumentContent(Guid id)
        {
            var content = context.DocumentContents.SingleOrDefault(c => c.Id == id);
            context.DocumentContents.Remove(content);
            context.SaveChanges();
        }

        public Guid FindDocumentContent(int id)
        {
            var contents = context.Documents.Where(d => d.Id == id).Select(c => new { contentId = c.DocumentContentId });
            foreach (var content in contents)
            {
                return content.contentId;
            }

            return Guid.Empty;
        }

        public bool AddDocument(Document document, List<DocumentType> documentTypes)
        {
            try
            {
                //add instance to context
                context.Documents.Add(document);
                //attach instance to context
                //context.Documents.Attach(document);

                foreach (DocumentType documentType in documentTypes)
                {
                    DocumentType type = context.DocumentTypes.Find(documentType.Id);
                    //attach instance to context
                    context.DocumentTypes.Attach(type);
                    

                    //like previous method add instance to navigation property
                    document.DocumentTypes.Add(type);
                }

                //Trang added code for feature Add Document History
                int isAdded = context.SaveChanges();
                if (isAdded != -1)
                {
                    bool isSuccessed = historyRepository.AddDocumentHistory(document, Helper.HistoryAction.Upload);
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public bool AddDocumentContent(DocumentContent documentContent)
        {
            try
            {
                context.DocumentContents.Add(documentContent);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        private void DeleteDocumentTypeByDocumentId(int id)
        {
            var document = context.Documents.Include("DocumentTypes").SingleOrDefault(d => d.Id == id);
            if (document != null)
            {
                foreach (var type in document.DocumentTypes.ToList())
                {
                    document.DocumentTypes.Remove(type);
                }
                context.SaveChanges();
            }
        }

        public bool UpdateDocument(Models.Document document)
        {
            Document documentRepo = mapper.Map<Document>(document);
            DeleteDocumentTypeByDocumentId(documentRepo.Id);

            try
            {
                var documentDB = context.Documents.Find(documentRepo.Id);
                documentDB.LastModified = documentRepo.LastModified;
                documentDB.LastModifiedBy = Helper.FAKE_USERID;
                int isUpdateDocument = context.SaveChanges();
                //attach instance to context
                context.Documents.Attach(documentDB);                
                foreach (var documentType in documentRepo.DocumentTypes.ToList())
                {
                    DocumentType type = context.DocumentTypes.Find(documentType.Id);
                    //attach instance to context
                    context.DocumentTypes.Attach(type);

                    //like previous method add instance to navigation property
                    documentDB.DocumentTypes.Add(type);
                }
                int isEdited = context.SaveChanges();
                if (isEdited != -1 && isUpdateDocument == 1)
                {
                    bool isSuccessed = historyRepository.AddDocumentHistory(documentRepo, Helper.HistoryAction.Edit);
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }

            return false;
        }

        public List<Document> LazyLoadDocuments(string propertyName, bool desc, int page, int pageSize, int parentId, out int totalRecords)
        {
            var documentsContext = context.Documents.Where(d => d.ParentId.Equals(null));
            if (parentId != 0)
            {
                documentsContext = context.Documents.Where(d => d.ParentId == parentId);
            }
            List<Document> documents = new List<Document>();

            totalRecords = documentsContext.Count();

            int skipRows = page * pageSize;
            if (desc)
            {
                documents = documentsContext.OrderBy(propertyName + " desc").Skip(skipRows).Take(pageSize).ToList();
            }
            else
            {
                documents = documentsContext.OrderBy(propertyName + " asc").Skip(skipRows).Take(pageSize).ToList();
            }
            return documents;
        }
    }
}
