using DocumentManagementSystem.Models;
using DocumentManagementSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.UnitTest
{
    public class Data
    {
        static object[] uploadCases =
        {
            new object[] {
                new Document
                {
                    DocumentName = "UnitTest.txt",
                    DocumentContent = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },
                    DocumentTypes = new List<DocumentType>
                    {
                        new DocumentType{Id = 1, Type = "HR"},
                        new DocumentType{Id = 2, Type = "IT"}
                    },
                    DocumentSize = 1024
                }, true },

            new object[] {
                new Document
                {
                    DocumentName = "Space",
                    DocumentContent = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },
                    DocumentTypes = new List<DocumentType>
                    {
                        new DocumentType{Id = 1, Type = "HR"},
                        new DocumentType{Id = 2, Type = "IT"}
                    },
                    DocumentSize = 2048
                }, false },

            new object[] {
                new Document
                {
                    DocumentName = "Window.txt",
                    DocumentContent = null,
                    DocumentTypes = new List<DocumentType>
                    {
                        new DocumentType{Id = 2, Type = "IT"}
                    },
                    DocumentSize = 2048
                }, false },

            new object[] {
                new Document
                {
                    DocumentName = "Pop.txt",
                    DocumentContent = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },
                    DocumentTypes = new List<DocumentType>
                    {
                        new DocumentType{Id = 1, Type = "HR"}
                    },
                    DocumentSize = 1048576
                }, true },

            new object[] {
                new Document
                {
                    DocumentName = "Dialog.docx",
                    DocumentContent = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },
                    DocumentTypes = new List<DocumentType>
                    {
                        new DocumentType{Id = 1, Type = "HR"}
                    },
                    DocumentSize = 0
                }, false },

             new object[] {
                new Document
                {
                    DocumentName = "ParentId.docx",
                    DocumentContent = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 , 0x20},
                    DocumentTypes = new List<DocumentType>
                    {
                        new DocumentType{Id = 1, Type = "HR"}
                    },
                    DocumentSize = 0,
                    ParentId = 0
                }, false },
        };

        public static List<Document> documents = new List<Document>
        {
            new Document
            {
                Id = 1,
                DocumentName = "Precio Vietnam",
                DocumentType = "folder",
                ParentId = 0,
                CreatedBy = new Account
                {
                    Id = 1,
                    Username = "IT"
                },
                LastModifiedBy = new Account
                {
                    Id = 1,
                    Username = "IT"
                }
            },

            new Document
            {
                Id = 2,
                DocumentName = "My Documents",
                DocumentType = "folder",
                ParentId = 0,
                CreatedBy = new Account
                {
                    Id = 1,
                    Username = "IT"
                },
                LastModifiedBy = new Account
                {
                    Id = 1,
                    Username = "IT"
                }
            },

            new Document
            {
                Id = 3,
                DocumentName = "Processes",
                DocumentType = "folder",
                ParentId = 1,
                CreatedBy = new Account
                {
                    Id = 2,
                    Username = "HR"
                },
                LastModifiedBy = new Account
                {
                    Id = 1,
                    Username = "IT"
                }
            },

            new Document
            {
                Id = 4,
                DocumentName = "Onboarding",
                DocumentType = "folder",
                ParentId = 1,
                CreatedBy = new Account
                {
                    Id = 3,
                    Username = "HR"
                },
                LastModifiedBy = new Account
                {
                    Id = 1,
                    Username = "IT"
                }
            },

            new Document
            {
                Id = 5,
                DocumentName = "Accounts",
                DocumentType = "folder",
                ParentId = 4,
                CreatedBy = new Account
                {
                    Id = 2,
                    Username = "HR"
                },
                LastModifiedBy = new Account
                {
                    Id = 1,
                    Username = "IT"
                }
            },

            new Document
            {
                Id = 6,
                DocumentName = "Templates",
                DocumentType = "folder",
                ParentId = 1,
                CreatedBy = new Account
                {
                    Id = 2,
                    Username = "HR"
                },
                LastModifiedBy = new Account
                {
                    Id = 1,
                    Username = "IT"
                }
            },

            new Document
            {
                Id = 7,
                DocumentName = "Newletters",
                DocumentType = "folder",
                ParentId = 1,
                CreatedBy = new Account
                {
                    Id = 2,
                    Username = "HR"
                },
                LastModifiedBy = new Account
                {
                    Id = 1,
                    Username = "IT"
                }
            },

            new Document
            {
                Id = 8,
                DocumentName = "Berna Klinge",
                DocumentType = "txt",
                ParentId = 1,
                CreatedBy = new Account
                {
                    Id = 2,
                    Username = "HR"
                },
                LastModifiedBy = new Account
                {
                    Id = 1,
                    Username = "IT"
                }
            },

            new Document
            {
                Id = 9,
                DocumentName = "Janella Guida",
                DocumentType = "xlsx",
                ParentId = 1,
                CreatedBy = new Account
                {
                    Id = 2,
                    Username = "HR"
                },
                LastModifiedBy = new Account
                {
                    Id = 1,
                    Username = "IT"
                }
            },

            new Document
            {
                Id = 10,
                DocumentName = "Lynette Murrieta",
                DocumentType = "pptx",
                ParentId = 1,
                CreatedBy = new Account
                {
                    Id = 2,
                    Username = "HR"
                },
                LastModifiedBy = new Account
                {
                    Id = 1,
                    Username = "IT"
                }
            },

            new Document
            {
                Id = 11,
                DocumentName = "Sharolyn Bouley",
                DocumentType = "pdf",
                ParentId = 1,
                CreatedBy = new Account
                {
                    Id = 2,
                    Username = "HR"
                },
                LastModifiedBy = new Account
                {
                    Id = 1,
                    Username = "IT"
                }
            },

        };

        static object[] lazyLoadCases =
        {
            new object[] {true, 1, 5, 1, "DocumentName"},
            new object[] {false, 0, 5, 1, "DocumentName"},
            new object[] {true, 1, 5, 1, "Created"},
            new object[] {false, 0, 5, 2, "Created"},
        };

        static List<Document> documentsAddingForTestDocumentHistory = new List<Document>()
        {
            new Document { Id = 1, DocumentName = "TestHistory_Adding_1", DocumentType = Helper.DocumentType.docx.ToString() },
            new Document { Id = 2, DocumentName = "TestHistory_Adding_2", DocumentType = Helper.DocumentType.docx.ToString() },
            new Document { Id = 3, DocumentName = "TestHistory_Adding_3", DocumentType = Helper.DocumentType.docx.ToString() },
            new Document { Id = 4, DocumentName = "TestHistory_Adding_4", DocumentType = Helper.DocumentType.docx.ToString() },
            new Document { Id = 5, DocumentName = "TestHistory_Adding_5", DocumentType = Helper.DocumentType.docx.ToString() }
        };

        static List<Document> documentsEditingForTestDocumentHistory = new List<Document>()
        {
            new Document { Id = 1, DocumentName = "TestHistory_Editing_1", DocumentType = Helper.DocumentType.docx.ToString() },
            new Document { Id = 1, DocumentName = "TestHistory_Editing_2", DocumentType = Helper.DocumentType.docx.ToString() },
            new Document { Id = 1, DocumentName = "TestHistory_Editing_3", DocumentType = Helper.DocumentType.docx.ToString() },
            new Document { Id = 1, DocumentName = "TestHistory_Editing_4", DocumentType = Helper.DocumentType.docx.ToString() },
            new Document { Id = 1, DocumentName = "TestHistory_Editing_5", DocumentType = Helper.DocumentType.docx.ToString() }
        };
    }
}
