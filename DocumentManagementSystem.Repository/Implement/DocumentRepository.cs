using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DocumentManagementSystem.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private int _count = 0;
        public string GetDocuments()
        {
            ++_count;
            return "Repository " + _count;
        }
    }
}
