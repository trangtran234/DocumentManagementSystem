using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentManagementSystem.Repository.Interface;

namespace DocumentManagementSystem.Repository.Implement
{
    public class DocumentRepository : IDocumentRepository
    {
        public string GetDocuments()
        {
            return "Get Data";
        }
    }
}
