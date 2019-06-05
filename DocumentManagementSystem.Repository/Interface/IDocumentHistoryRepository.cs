using DocumentManagementSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Repository.Interface
{
    public interface IDocumentHistoryRepository
    {
        bool AddDocumentHistory(Document document, Helper.HistoryAction actionEvent);
        List<DocumentHistory> GetDocumentHistories(int documentId);
    }
}
