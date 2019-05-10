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
            IList<Repository.Document> documentsRepo = documentRepository.GetAllDocuments();
            IList<Models.Document> documents = AutoMapperConfig.GetMapper().Map<List<Models.Document>>(documentsRepo);
            return documents;
        }

        public IList<Models.Document> GetDocumentByContentId(Guid id)
        {
            IList<Repository.Document> documentsRepo = documentRepository.GetDocumentByContentId(id);
            IList<Models.Document> documents = AutoMapperConfig.GetMapper().Map<List<Models.Document>>(documentsRepo);
            return documents;
        }

        public IList<Models.Document> GetDocumentByParentId(int id)
        {
            IList<Repository.Document> documentsRepo = documentRepository.GetDocumentByParentId(id);
            IList<Models.Document> documents = AutoMapperConfig.GetMapper().Map<List<Models.Document>>(documentsRepo);
            return documents;
        }

        public Models.Document GetDocumentByDocumentId(int id)
        {
            Repository.Document documentRepo = documentRepository.GetDocumentByDocumentId(id);
            Models.Document document = AutoMapperConfig.GetMapper().Map<Models.Document>(documentRepo);
            return document;
        }

        public IList<Models.Document> GetDocumentByDocumentType(string type)
        {
            IList<Repository.Document> documentsRepo = documentRepository.GetDocumentByDocumentType(type);
            IList<Models.Document> documents = AutoMapperConfig.GetMapper().Map<List<Models.Document>>(documentsRepo);
            return documents;
        }
    }
}
