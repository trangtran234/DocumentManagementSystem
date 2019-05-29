﻿using DocumentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.Services
{
    public interface IDocumentService
    {
        List<Document> GetAllDocument();
        List<Document> GetDocumentByParentId(int id);
        List<DocumentTreeView> GetFolders();
        List<DocumentTreeView> GetFoldersByFolderId(int id);
        Document GetDocumentByDocumentId(int id);
        void DeleteDocument(int id);
        bool AddDocument(Document document);
        bool UpdateDocument(Document document);
    }
}
