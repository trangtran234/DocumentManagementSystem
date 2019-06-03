using DocumentManagementSystem.Models.Common;
using DocumentManagementSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Repository.Implement
{
    public class DocumentHistoryRepository: IDocumentHistoryRepository
    {
        private readonly DocumentManagementSystemEntities context;

        public DocumentHistoryRepository(DocumentManagementSystemEntities context)
        {
            this.context = context;
        }

        public bool AddDocumentHistory(Document document, Helper.HistoryAction actionEvent)
        {
            DocumentHistory documentHistory = new DocumentHistory
            {
                DocumentId = document.Id,
                ActionId = (int)actionEvent,
                UserId = Helper.FAKE_USERID_TO_ADD_HISTORY,
                Date = DateTime.Now
            };
            context.DocumentHistories.Add(documentHistory);
            int isAddedHistory = context.SaveChanges();
            Console.WriteLine("History Repo add history document status: {0}");
            if(isAddedHistory != -1)
            {
                return true;
            }
            return false;
        }

        public List<DocumentHistory> GetDocumentHistories()
        {
            List<DocumentHistory> documentHistories = context.DocumentHistories.ToList();
            return documentHistories;
        }
    }
}
