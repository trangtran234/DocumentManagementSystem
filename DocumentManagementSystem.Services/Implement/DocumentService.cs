using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentManagementSystem.Repository.Interface;
using DocumentManagementSystem.Services.Interface;

namespace DocumentManagementSystem.Services.Implement
{
    public class DocumentService : IDocumentService
    {
        private IDocumentRepository _documentRepository;
        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public string GetAllDocument()
        {
            return _documentRepository.GetDocuments();
        }
    }
}
