using System;
using System.Collections.Generic;
using DocumentManagementSystem.IRepository;
using DocumentManagementSystem.Models;

namespace DocumentManagementSystem.Services
{
    public class DocumentService : IDocumentService
    {
        private IDocumentRepository documentRepository;
        private readonly IDocumentHistoryRepository documentHistoryRepository;
        public DocumentService(IDocumentRepository documentRepository, IDocumentHistoryRepository documentHistoryRepository)
        {
            this.documentRepository = documentRepository;
            this.documentHistoryRepository = documentHistoryRepository;
        }

        public List<Models.Document> GetAllDocument()
        {
            List<Models.Document> documents = documentRepository.GetAllDocuments();
            return documents;
        }

        public List<Models.Document> GetDocumentByParentId(int id)
        {
            List<Models.Document> documents = documentRepository.GetDocumentByParentId(id);
            return documents;
        }

        public Models.Document GetDocumentByDocumentId(int id)
        {
            Models.Document document = documentRepository.GetDocumentByDocumentId(id);
            return document;
        }

        public List<DocumentTreeView> GetFolders()
        {
            List<DocumentTreeView> documents = documentRepository.GetFolders();
            return documents;
        }

        public List<DocumentTreeView> GetFoldersByFolderId(int id)
        {
            List<DocumentTreeView> documents = documentRepository.GetFoldersByFolderId(id);
            return documents;
        }

        public void DeleteDocument(int id)
        {
            Guid contentId = documentRepository.FindDocumentContent(id);
            documentRepository.DeleteDocument(id);
            documentRepository.DeleteDocumentContent(contentId);
        }

        public bool UpdateDocument(Models.Document document)
        {
            var currentDay = DateTime.Now;
            document.LastModified = currentDay;
            return documentRepository.UpdateDocument(document);
        }

        public List<Models.Document> LazyLoadDocuments(bool desc, int page, int pageSize, int parentId, string propertyName, out int totalRecords)
        {
            List<Models.Document> documents = documentRepository.LazyLoadDocuments(propertyName, desc, page, pageSize, parentId, out totalRecords);

            return documents;
        }

        public List<Models.DocumentHistory> GetDocumentHistories(int documentId)
        {
            List<Models.DocumentHistory> documentHistories = documentHistoryRepository.GetDocumentHistories(documentId);
            return documentHistories;
        }
    }
}
