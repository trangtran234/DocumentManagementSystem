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
        IList<Document> GetAllDocument();
        IList<Document> GetDocumentByParentId(int id);
        IList<DocumentTreeViewDTO> GetFolders();
        IList<DocumentTreeViewDTO> GetFoldersByFolderId(int id);
        Document GetDocumentByDocumentId(int id);
    }
}
