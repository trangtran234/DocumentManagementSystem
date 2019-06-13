using DocumentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DocumentManagementSystem.Models.Common;

namespace DocumentManagementSystem.Services
{
    public interface IDocumentService
    {
        List<Document> GetAllDocument();
        List<Document> GetDocumentByParentId(int id);
        List<DocumentTreeView> GetFolders();
        List<DocumentTreeView> GetFoldersByFolderId(int id);
        Document GetDocumentByDocumentId(int id);
        void DeleteDocument(int id);
        bool AddDocument(Document document);
        bool UpdateDocument(Models.Document document);
        List<Document> LazyLoadDocuments(bool desc, int page, int pageSize, int parentId, string propertyName, out int totalRecords);
        List<DocumentHistory> GetDocumentHistories(int documentId);
    }
}
