using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentManagementSystem.Repository;
using AutoMapper;

namespace DocumentManagementSystem.Services
{
    public class DocumentService : IDocumentService
    {
        private IDocumentRepository documentRepository;
        public DocumentService(IDocumentRepository documentRepository)
        {
            this.documentRepository = documentRepository;
        }

        public List<Models.Document> GetAllDocument()
        {
            List<Document> listDocuments = documentRepository.GetAllDocuments();
            List<Models.Document> listDocumentsView = new List<Models.Document>();
            foreach (Document document in listDocuments)
            {
                Models.Document documentView = Mapper.Map<Document, Models.Document>(document);
                listDocumentsView.Add(documentView);
            }
            return listDocumentsView;
        }
    }
}
