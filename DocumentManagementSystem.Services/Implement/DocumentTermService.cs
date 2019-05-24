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
    public class DocumentTermService : IDocumentTermService
    {
        private IDocumentTermRepository documentTermRepository;
        private IMapper mapper;

        public DocumentTermService(IDocumentTermRepository documentTermService, IAutoMapperConfig mapper)
        {
            this.documentTermRepository = documentTermService;
            this.mapper = mapper.GetMapper();
        }

        public List<Models.DocumentTerm> GetAllDocumentTerms()
        {

            List<Repository.DocumentTerm> documentTermsRepo = documentTermRepository.GetAllDocumentTerms();
            List<Models.DocumentTerm> documentTerms = mapper.Map<List<Models.DocumentTerm>>(documentTermsRepo);

            return documentTerms;
        }
    }
}
