using DocumentManagementSystem.Models;
using DocumentManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.UnitTest.Mockup
{
    public class DocumentTypeMockup : IDocumentTypeRepository
    {
        public List<Models.DocumentType> GetAllDocumentTypes()
        {
            List<Models.DocumentType> documentTypes = new List<Models.DocumentType>()
            {
                new Models.DocumentType { Id = 1 , Type = "Training" },
                new Models.DocumentType { Id = 2 , Type = "Tax" },
                new Models.DocumentType { Id = 3 , Type = "HR" }
            };
            return documentTypes;
        }
    }
}
