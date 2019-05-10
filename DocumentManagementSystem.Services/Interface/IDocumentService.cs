using DocumentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Services
{
    public interface IDocumentService
    {
        IList<Document> GetAllDocument();
        IList<Document> GetDocumentByContentId(Guid id);
        IList<Document> GetDocumentByParentId(int id);
        IList<Document> GetDocumentByDocumentType(string type);
        Document GetDocumentByDocumentId(int id);
    }
}
