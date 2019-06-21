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
        private List<DocumentType> types = new List<DocumentType>();

        public List<DocumentType> GetAllDocumentTypes()
        {
            return types;
        }
    }
}
