using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DocumentManagementSystem.Models;
using DocumentManagementSystem.Repository;
using DocumentManagementSystem.Services.Automapper;

namespace DocumentManagementSystem.Services
{
    public class DocumentService : IDocumentService
    {
        private IDocumentRepository documentRepository;
        private IMapper mapper;
        public DocumentService(IDocumentRepository documentRepository, IAutoMapperConfig mapper)
        {
            this.documentRepository = documentRepository;
            this.mapper = mapper.GetMapper();
        }

        public IList<Models.Document> GetAllDocument()
        {
            IList<Repository.Document> documentsRepo = documentRepository.GetAllDocuments();
            IList<Models.Document> documents = mapper.Map<List<Models.Document>>(documentsRepo);
            return documents;
        }

        public IList<Models.Document> GetDocumentByParentId(int id)
        {
            IList<Repository.Document> documentsRepo = documentRepository.GetDocumentByParentId(id);
            IList<Models.Document> documents = mapper.Map<List<Models.Document>>(documentsRepo);
            return documents;
        }

        public Models.Document GetDocumentByDocumentId(int id)
        {
            Repository.Document documentRepo = documentRepository.GetDocumentByDocumentId(id);
            Models.Document document = mapper.Map<Models.Document>(documentRepo);
            return document;
        }

        public IList<DocumentTreeViewDTO> GetFolders()
        {
            IList<Repository.Document> documentsRepo = documentRepository.GetFolders();
            IList<DocumentTreeViewDTO> documents = mapper.Map<List<DocumentTreeViewDTO>>(documentsRepo);
            return documents;
        }

        public IList<DocumentTreeViewDTO> GetFoldersByFolderId(int id)
        {
            IList<Repository.Document> documentsRepo = documentRepository.GetFoldersByFolderId(id);
            IList<DocumentTreeViewDTO> documents = mapper.Map<List<DocumentTreeViewDTO>>(documentsRepo);
            return documents;
        }

        public bool AddListDocument(List<Models.Document> listDocuments)
        {
            List<Models.DocumentContent> listContents = new List<Models.DocumentContent>();
            foreach (Models.Document document in listDocuments)
            {                
                if (document.DocumentContent != null)
                {
                    Models.DocumentContent content = new Models.DocumentContent();

                    content.Id = Guid.NewGuid();
                    document.DocumentContentId = content.Id;
                    content.Content = document.DocumentContent;
                    listContents.Add(content);
                }
            }
            
            List<Repository.Document> listDocumentsRepo = mapper.Map<List<Repository.Document>>(listDocuments);
            List<Repository.DocumentContent> listContentsRepo = mapper.Map<List<Repository.DocumentContent>>(listContents);

            documentRepository.AddDocumentContent(listContentsRepo);
            documentRepository.AddListDocument(listDocumentsRepo);

            return true;
        }
    }
}
