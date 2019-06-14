using DocumentManagementSystem.IRepository;
using DocumentManagementSystem.Services.Interface;
using System;
using System.Collections.Generic;

namespace DocumentManagementSystem.Services.Implement
{
    public class UploadService : IUploadService
    {
        private IDocumentRepository documentRepository;

        public UploadService(IDocumentRepository documentRepository)
        {
            this.documentRepository = documentRepository;
        }

        public bool AddDocument(Models.Document document)
        {
            string[] arr = Common.GetDocumentTypes(document.DocumentName, ".");
            document.DocumentName = arr[0];
            document.DocumentType = arr[arr.Length - 1];

            var currentDay = DateTime.Now;
            document.Created = currentDay;
            document.LastModified = currentDay;

            if (document.DocumentType.ToUpper() != Common.DocumentType.folder.ToString().ToUpper()
                && document.DocumentContent != null
                && ( document.ParentId != 0 || document.ParentId.ToString() != null)
                && (document.DocumentSize > Common.MIX_FILE_SIZE 
                && document.DocumentSize <= Common.LIMITED_FILE_SIZE ))
            {
                Models.DocumentContent content = new Models.DocumentContent();

                content.Id = Guid.NewGuid();
                document.DocumentContentId = content.Id;
                content.Content = document.DocumentContent;

                List<Models.DocumentType> types = new List<Models.DocumentType>();
                foreach (Models.DocumentType dt in document.DocumentTypes)
                {
                    Models.DocumentType type = new Models.DocumentType();
                    type.Id = dt.Id;
                    type.Type = dt.Type;

                    types.Add(type);
                }

                document.DocumentTypes = null;

                if (documentRepository.AddDocumentContent(content) && documentRepository.AddDocument(document, types))
                {
                    return true;
                }
                return false;
            }

            return false;
        }
    }
}
