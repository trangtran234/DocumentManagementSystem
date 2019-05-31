using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DocumentManagementSystem.Models;
using DocumentManagementSystem.Repository;
using DocumentManagementSystem.Services.Automapper;

namespace DocumentManagementSystem.Services
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private IDocumentTypeRepository documentTypeRepository;
        private IMapper mapper;

        public DocumentTypeService(IDocumentTypeRepository documentTypeService, IAutoMapperConfig mapper)
        {
            this.documentTypeRepository = documentTypeService;
            this.mapper = mapper.GetMapper();
        }

        public List<Models.DocumentType> GetAllDocumentTypes()
        {

            List<Repository.DocumentType> documentTypeRepo = documentTypeRepository.GetAllDocumentTypes();
            List<Models.DocumentType> documentTypes = mapper.Map<List<Models.DocumentType>>(documentTypeRepo);

            return documentTypes;
        }
    }
}
