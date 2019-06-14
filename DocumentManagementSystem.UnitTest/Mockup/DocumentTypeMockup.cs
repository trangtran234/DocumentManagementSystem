using DocumentManagementSystem.IRepository;
using DocumentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.UnitTest.Mockup
{
    public class DocumentTypeMockup : IDocumentTypeRepository
    {
        public List<DocumentType> GetAllDocumentTypes()
        {
            List<DocumentType> documentTypes = new List<Models.DocumentType>()
            {
                new DocumentType { Id = 1 , Type = "Training" },
                new DocumentType { Id = 2 , Type = "Tax" },
                new DocumentType { Id = 3 , Type = "HR" }
            };
            return documentTypes;
        }
    }
}
