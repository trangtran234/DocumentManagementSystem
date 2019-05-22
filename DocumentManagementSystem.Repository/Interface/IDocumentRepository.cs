using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Repository
{
    public interface IDocumentRepository
    {
        List<Document> GetAllDocuments();
        List<Document> GetDocumentByParentId(int id);
        List<Document> GetFolders();
        List<Document> GetFoldersByFolderId(int id);
        Document GetDocumentByDocumentId(int id);
        void AddListDocument(List<Document> listDocuments);
        void AddDocumentContent(List<DocumentContent> documentContent);
        List<Document> GetDocumentsTop(int top);
        void DeleteDocument(int id);
        void DeleteDocumentContent(Guid id);
        Guid FindDocumentContent(int id);
    }
}
