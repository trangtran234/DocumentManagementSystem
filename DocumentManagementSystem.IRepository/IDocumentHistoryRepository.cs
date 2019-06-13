using DocumentManagementSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.IRepository
{
    public interface IDocumentHistoryRepository
    {
        bool AddDocumentHistory(Models.Document document, Helper.HistoryAction actionEvent);
        List<Models.DocumentHistory> GetDocumentHistories(int documentId);
    }
}
