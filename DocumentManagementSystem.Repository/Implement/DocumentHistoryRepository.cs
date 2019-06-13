using AutoMapper;
using DocumentManagementSystem.Models.Common;
using DocumentManagementSystem.Repository.Automapper;
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
        private IMapper mapper;

        public DocumentHistoryRepository(DocumentManagementSystemEntities context, IAutoMapperConfig mapper)
        {
            this.context = context;
            this.mapper = mapper.GetMapper();
        }

        public bool AddDocumentHistory(Models.Document document, Helper.HistoryAction actionEvent)
        {
            Document documentRepo = mapper.Map<Document>(document);
            int userId = (int)actionEvent == 1 ? 1 : 3;

            DocumentHistory documentHistory = new DocumentHistory
            {
                DocumentId = documentRepo.Id,
                ActionId = (int)actionEvent,
                UserId = userId,
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

        public List<Models.DocumentHistory> GetDocumentHistories(int documentId)
        {
            List<DocumentHistory> documentHistoriesRepo = context.DocumentHistories.Where(d => d.DocumentId == documentId).OrderByDescending(d => d.Id).ToList();
            List<Models.DocumentHistory> documentHistories = mapper.Map<List<Models.DocumentHistory>>(documentHistoriesRepo);
            return documentHistories;
        }
    }
}
