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
    public class DocumentHistoryRepoMockup : IDocumentHistoryRepository
    {
        private IMapper mapper;

        public DocumentHistoryRepoMockup(IAutoMapperConfig mapper)
        {
            this.mapper = mapper.GetMapper();
        }

        private List<DocumentHistory> DocumentHistoriesStored()
        {
            List<DocumentHistory> documentHistories = new List<DocumentHistory>()
            {
                new DocumentHistory { Id = 1, DocumentId = 1, Document = new Document { Id = 1,  DocumentName = "Test", DocumentType = "docx"}, ActionId = 1, Account = new Account { Id = 1, Username = "Admin"}, Date = DateTime.Now, UserId = 1 },
                new DocumentHistory { Id = 2, DocumentId = 2, Document = new Document { Id = 2,  DocumentName = "Test", DocumentType = "docx"}, ActionId = 2, Account = new Account { Id = 1, Username = "Admin"}, Date = DateTime.Now, UserId = 1 }
            };
            return documentHistories;
        }

        public bool AddDocumentHistory(Document document, Helper.HistoryAction actionEvent)
        {
            throw new NotImplementedException();
        }

        public List<Models.DocumentHistory> GetDocumentHistories(int documentId)
        {
            List<DocumentHistory> documentHistoriesRepo = DocumentHistoriesStored().Where(d => d.DocumentId == documentId).OrderByDescending(d => d.Id).ToList();
            List<Models.DocumentHistory> documentHistories = mapper.Map<List<Models.DocumentHistory>>(documentHistoriesRepo);
            return documentHistories;
        }
    }
}
