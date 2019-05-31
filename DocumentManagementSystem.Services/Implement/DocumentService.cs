﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public List<DocumentTreeView> GetFolders()
        {
            List<Repository.Document> documentsRepo = documentRepository.GetFolders();
            List<DocumentTreeView> documents = mapper.Map<List<DocumentTreeView>>(documentsRepo);
            return documents;
        }

        public List<DocumentTreeView> GetFoldersByFolderId(int id)
        {
            List<Repository.Document> documentsRepo = documentRepository.GetFoldersByFolderId(id);
            List<DocumentTreeView> documents = mapper.Map<List<DocumentTreeView>>(documentsRepo);
            return documents;
        }

        public void DeleteDocument(int id)
        {
            Guid contentId = documentRepository.FindDocumentContent(id);
            documentRepository.DeleteDocument(id);
            documentRepository.DeleteDocumentContent(contentId);
        }

        public bool AddDocument(Models.Document document)
        {
            string[] arr = Common.GetDocumentTypes(document.DocumentName, ".");
            document.DocumentName = arr[0];
            document.DocumentType = arr[arr.Length - 1];

            var currentDay = DateTime.Now;
            document.Created = currentDay;
            document.LastModified = currentDay;

            if (document.DocumentType != null 
                && document.DocumentContent != null 
                && document.DocumentSize <= Common.LIMITED_FILE_SIZE)
            {
                Models.DocumentContent content = new Models.DocumentContent();

                content.Id = Guid.NewGuid();
                document.DocumentContentId = content.Id;
                content.Content = document.DocumentContent;

                List<Models.DocumentType> types = new List<Models.DocumentType>();
                foreach(Models.DocumentType dt in document.DocumentTypes)
                {
                    Models.DocumentType type = new Models.DocumentType();
                    type.Id = dt.Id;
                    type.Type = dt.Type;

                    types.Add(type);
                }

                document.DocumentTypes = null;

                Repository.DocumentContent contentRepository = mapper.Map<Repository.DocumentContent>(content);
                Repository.Document documentRepo = mapper.Map<Repository.Document>(document);
                List<Repository.DocumentType> typesRepository = mapper.Map<List<Repository.DocumentType>>(types);

                if(documentRepository.AddDocumentContent(contentRepository) && documentRepository.AddDocument(documentRepo, typesRepository))
                {
                    return true;
                }
                return false;
            }

            return false;
        }

        public bool UpdateDocument(Models.Document document)
        {
            var currentDay = DateTime.Now;
            document.LastModified = currentDay;
            Repository.Document documentRepo = mapper.Map<Repository.Document>(document);
            return documentRepository.UpdateDocument(documentRepo);
        }

        public List<Models.Document> LazyLoadDocuments(bool desc, int page, int pageSize, int parentId,out int totalRecords)
        {
            Expression<Func<Repository.Document, string>> expression = d => d.DocumentName;
            List<Repository.Document> documentListRepository = documentRepository.LazyLoadDocuments(expression, desc, page, pageSize, parentId,out totalRecords);

            List<Models.Document> documents = mapper.Map<List<Models.Document>>(documentListRepository);

            return documents;
        }
    }
}
