using DocumentManagementSystem.IRepository;
using DocumentManagementSystem.Models;
using DocumentManagementSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.UnitTest.Mockup
{
    public class DocumentHistoryMockup : IDocumentHistoryRepository
    {
        private readonly List<Models.DocumentHistory> documentHistories = new List<Models.DocumentHistory>();
        
        public bool AddDocumentHistory(Models.Document document, Helper.HistoryAction actionEvent)
        {
            int lenght = documentHistories.Count;
            int userId = (int)actionEvent == 1 ? 1 : 3;
            Models.DocumentHistory documentHistory = new Models.DocumentHistory()
            {
                DocumentId = document.Id,
                ActionEvent = actionEvent,
                UserId = userId,
                Date = DateTime.Now
            };
            documentHistories.Add(documentHistory);
            int isAddedHistory = documentHistories.Count;
            if (isAddedHistory > lenght)
            {
                return true;
            }
            return false;
        }

        public List<Models.DocumentHistory> GetDocumentHistories(int documentId)
        {
            List<Models.DocumentHistory> result = documentHistories.Where(d => d.DocumentId == documentId).ToList();
            return result;
        }
    }
}
