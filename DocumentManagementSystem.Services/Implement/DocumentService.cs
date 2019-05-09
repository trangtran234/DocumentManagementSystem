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
        private readonly IAutoMapperConfig mapper = new AutoMapperConfig();

        public DocumentService(IDocumentRepository documentRepository)
        {
            this.documentRepository = documentRepository;
        }

        private Guid ConvertIntToGuid(int value)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }

        public IList<Models.Document> GetAllDocument()
        { 
            return mapper.GetMapper().Map<List<Models.Document>>(documentRepository.GetAllDocuments());
        }

        public IList<Models.Document> GetDocumentByContentId(int id)
        {
            return mapper.GetMapper().Map<List<Models.Document>>(documentRepository.GetDocumentByContentId(ConvertIntToGuid(id)));
        }

        public IList<Models.Document> GetDocumentByParentId(int id)
        {
            return mapper.GetMapper().Map<List<Models.Document>>(documentRepository.GetDocumentByParentId(id));
        }

        public Models.Document GetDocumentByDocumentId(int id)
        {
            return mapper.GetMapper().Map<Models.Document>(documentRepository.GetDocumentByDocumentId(id));
        }
    }
}
