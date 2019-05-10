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
        IList<Document> GetDocumentByContentId(Guid id);
        IList<Document> GetDocumentByDocumentType(string type);
        Document GetDocumentByDocumentId(int id);
    }
}
