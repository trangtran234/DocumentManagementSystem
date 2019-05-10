using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentManagementSystem.Models;
using DocumentManagementSystem.Repository;
using DocumentManagementSystem.Services.Automapper;

namespace DocumentManagementSystem.Services
{
    public class DocumentService : IDocumentService
    {
        private IDocumentRepository documentRepository;
        public DocumentService(IDocumentRepository documentRepository)
        {
            this.documentRepository = documentRepository;
        }

        public IList<Models.Document> GetAllDocument()
        {
            IList<Models.Document> documents = AutoMapperConfig.GetMapper().Map<List<Models.Document>>(documentRepository.GetAllDocuments());
            return documents;
        }

        public IList<Models.Document> GetDocumentByContentId(Guid id)
        {
            IList<Models.Document> documents = AutoMapperConfig.GetMapper().Map<List<Models.Document>>(documentRepository.GetDocumentByContentId(id));
            return documents;
        }

        public IList<Models.Document> GetDocumentByParentId(int id)
        {
            IList<Models.Document> documents = AutoMapperConfig.GetMapper().Map<List<Models.Document>>(documentRepository.GetDocumentByParentId(id));
            return documents;
        }

        public Models.Document GetDocumentByDocumentId(int id)
        {
            Models.Document document = AutoMapperConfig.GetMapper().Map<Models.Document>(documentRepository.GetDocumentByDocumentId(id));
            return document;
        }
    }
}
