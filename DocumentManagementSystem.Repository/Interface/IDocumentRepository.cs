using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Repository
{
    public interface IDocumentRepository
    {
        IList<Document> GetAllDocuments();
        IList<Document> GetDocumentByParentId(int id);
        IList<Document> GetFolders();
        IList<Document> GetFoldersByFolderId(int id);
        Document GetDocumentByDocumentId(int id);
        void AddListDocument(List<Document> listDocuments);
        void AddDocumentContent(List<DocumentContent> documentContent);
    }
}
