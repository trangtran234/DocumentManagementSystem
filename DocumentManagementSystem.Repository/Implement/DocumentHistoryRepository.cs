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
                UserId = Helper.FAKE_USERID,
                Date = DateTime.Now
            };
            context.DocumentHistories.Add(documentHistory);
            int isAddedHistory = context.SaveChanges();
            if(isAddedHistory != -1)
            {
                return true;
            }
            return false;
        }

        public List<DocumentHistory> GetDocumentHistories()
        {
            List<DocumentHistory> documentHistories = context.DocumentHistories.OrderByDescending(d => d.Id).ToList();
            return documentHistories;
        }
    }
}
