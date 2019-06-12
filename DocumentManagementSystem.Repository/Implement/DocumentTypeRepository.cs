using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DocumentManagementSystem.Repository.Automapper;
namespace DocumentManagementSystem.Repository
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private DocumentManagementSystemEntities context;
        private IMapper mapper;

        public DocumentTypeRepository(DocumentManagementSystemEntities context, IAutoMapperConfig mapper)
        {
            this.context = context;
            this.mapper = mapper.GetMapper();
        }

        public List<Models.DocumentType> GetAllDocumentTypes()
        {
            List<DocumentType> documentTypes = context.DocumentTypes.Select(d => d).ToList();
            List<Models.DocumentType> documentTypesModel = mapper.Map<List<Models.DocumentType>>(documentTypes);
            return documentTypesModel;
        }
    }
}
