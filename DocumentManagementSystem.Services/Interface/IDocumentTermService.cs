using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Services
{
    public interface IDocumentTermService
    {
        List<Models.DocumentTerm> GetAllDocumentTerms();
    }
}
