using DocumentManagementSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Repository
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private IDocumentContext context;

        public DocumentTypeRepository(IDocumentContext context)
        {
            this.context = context;
        }

        public List<DocumentType> GetAllDocumentTypes()
        {
            List<DocumentType> documentTypes = context.DocumentTypes.Select(d => d).ToList();
            return documentTypes;
        }
    }
}
