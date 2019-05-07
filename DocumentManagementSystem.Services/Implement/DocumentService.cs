using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentManagementSystem.Repository;
using DocumentManagementSystem.Services.Interface;

namespace DocumentManagementSystem.Services.Implement
{
    public class DocumentService : IDocumentService
    {
        private int _count = 0;
        private IDocumentRepository _documentRepository;
        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public string GetAllDocument()
        {
            ++_count;
            return _documentRepository.GetDocuments() + " service " + _count;
        }
    }
}
