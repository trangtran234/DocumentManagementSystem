using DocumentManagementSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Repository
{
    public class DocumentTermRepository : IDocumentTermRepository
    {
        private IDocumentContext context;

        public DocumentTermRepository(IDocumentContext context)
        {
            this.context = context;
        }

        public List<DocumentTerm> GetAllDocumentTerms()
        {
            List<DocumentTerm> documentTerms = context.DocumentTerms.Select(d => d).ToList();
            return documentTerms;
        }
    }
}
