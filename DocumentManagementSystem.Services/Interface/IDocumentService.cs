using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentManagementSystem.Repository;

namespace DocumentManagementSystem.Services
{
    public interface IDocumentService
    {
        List<Models.Document> GetAllDocument();
    }
}
