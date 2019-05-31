using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Repository
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private DocumentManagementSystemEntities context;

        public DocumentTypeRepository(DocumentManagementSystemEntities context)
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
