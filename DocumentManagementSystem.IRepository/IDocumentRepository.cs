﻿using DocumentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.IRepository
{
    public interface IDocumentRepository
    {
        List<Models.Document> GetAllDocuments();
        List<Models.Document> GetDocumentByParentId(int id);
        List<Models.DocumentTreeView> GetFolders();
        List<Models.DocumentTreeView> GetFoldersByFolderId(int id);
        Models.Document GetDocumentByDocumentId(int id);
        void DeleteDocument(int id);
        void DeleteDocumentContent(Guid id);
        Guid FindDocumentContent(int id);
        bool AddDocument(Document document, List<DocumentType> types);
        bool UpdateDocument(Models.Document document);
    }
}
