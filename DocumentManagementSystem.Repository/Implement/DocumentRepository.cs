using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DocumentManagementSystem.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        public List<Document> GetAllDocuments()
        {
            List<Document> listDocumemts = new List<Document>();
            using(var ctx = new DocumentManagementSystemEntities())
            {
                listDocumemts = ctx.Documents.Select(d => d).ToList();
            }
            return listDocumemts;
        }
    }
}
