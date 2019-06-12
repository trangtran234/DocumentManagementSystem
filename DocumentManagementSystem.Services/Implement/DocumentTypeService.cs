﻿using System;
using System.Collections.Generic;
using DocumentManagementSystem.Repository;

namespace DocumentManagementSystem.Services
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private IDocumentTypeRepository documentTypeRepository;

        public DocumentTypeService(IDocumentTypeRepository documentTypeRepository)
        {
            this.documentTypeRepository = documentTypeRepository;
        }

        public List<Models.DocumentType> GetAllDocumentTypes()
        {
            List<Models.DocumentType> documentTypes = documentTypeRepository.GetAllDocumentTypes();

            return documentTypes;
        }
    }
}
