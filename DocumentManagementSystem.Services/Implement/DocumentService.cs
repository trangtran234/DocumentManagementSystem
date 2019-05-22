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

        public List<Models.Document> GetAllDocument()
        {
            List<Repository.Document> documentsRepo = documentRepository.GetAllDocuments();
            List<Models.Document> documents = mapper.Map<List<Models.Document>>(documentsRepo);
            return documents;
        }

        public List<Models.Document> GetDocumentByParentId(int id)
        {
            List<Repository.Document> documentsRepo = documentRepository.GetDocumentByParentId(id);
            List<Models.Document> documents = mapper.Map<List<Models.Document>>(documentsRepo);
            return documents;
        }

        public Models.Document GetDocumentByDocumentId(int id)
        {
            Repository.Document documentRepo = documentRepository.GetDocumentByDocumentId(id);
            Models.Document document = mapper.Map<Models.Document>(documentRepo);
            return document;
        }

        public List<DocumentTreeViewDTO> GetFolders()
        {
            List<Repository.Document> documentsRepo = documentRepository.GetFolders();
            List<DocumentTreeViewDTO> documents = mapper.Map<List<DocumentTreeViewDTO>>(documentsRepo);
            return documents;
        }

        public List<DocumentTreeViewDTO> GetFoldersByFolderId(int id)
        {
            List<Repository.Document> documentsRepo = documentRepository.GetFoldersByFolderId(id);
            List<DocumentTreeViewDTO> documents = mapper.Map<List<DocumentTreeViewDTO>>(documentsRepo);
            return documents;
        }

        public List<Models.Document> AddListDocument(List<Models.Document> listDocuments)
        {
            List<Models.DocumentContent> listContents = new List<Models.DocumentContent>();
            List<Models.Document> listInvalidData = new List<Models.Document>();
            foreach (Models.Document document in listDocuments)
            {
                string[] arr = Common.GetDocumentTypes(document.DocumentName, ".");
                document.DocumentName = arr[0];
                document.DocumentType = arr[arr.Length - 1];

                var currentDay = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                document.Created = currentDay;
                document.LastModified = currentDay;

                if (document.DocumentType == null || document.DocumentContent == null)
                {
                    listInvalidData.Add(document);
                    return listInvalidData;
                }
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

            List<Repository.Document> listDocumentsSuccess = documentRepository.GetDocumentsTop(listDocumentsRepo.Count());
            List<Models.Document> listDocumentsModel = mapper.Map<List<Models.Document>>(listDocumentsSuccess);

            return listDocumentsModel;
        }

        public void DeleteDocument(int id)
        {
            Guid contentId = documentRepository.FindDocumentContent(id);
            documentRepository.DeleteDocument(id);
            documentRepository.DeleteDocumentContent(contentId);
        }
    }
}
