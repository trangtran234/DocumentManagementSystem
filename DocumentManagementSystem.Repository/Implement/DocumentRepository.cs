﻿using DocumentManagementSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentManagementSystem.Repository.Common;
namespace DocumentManagementSystem.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private IDocumentContext context;

        public DocumentRepository(IDocumentContext context)
        {
            this.context = context;
        }

        public List<Document> GetDocumentByParentId(int id)
        {
            var documents = context.Documents.Where(d => d.ParentId == id).ToList();
            return documents;
        }

        public List<Document> GetAllDocuments()
        {
            List<Document> documents = context.Documents.Select(d => d).ToList();
            return documents;
        }

        public Document GetDocumentByDocumentId(int id)
        {
            Document document = context.Documents.Include("DocumentTags").FirstOrDefault<Document>(d => d.Id == id);
            return document;
        }

        public List<Document> GetFolders()
        {
            List<Document> documents = context.Documents.Where(d => d.DocumentType == Helper.DocumentType.folder.ToString()).ToList();
            return documents;
        }

        public List<Document> GetFoldersByFolderId(int id)
        {
            List<Document> documents = context.Documents.Where(d => d.ParentId == id && d.DocumentType == Helper.DocumentType.folder.ToString()).ToList();
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

                context.SaveChanges();
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
    }
}
