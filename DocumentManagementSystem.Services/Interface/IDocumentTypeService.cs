using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Services
{
    public interface IDocumentTypeService
    {
        List<Models.DocumentType> GetAllDocumentTypes();
    }
}
