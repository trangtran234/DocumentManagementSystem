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
        static object[] documents =
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
                }, 1 },

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
                }, 0 },

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
                }, 0 },

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
                }, 1 },

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
                }, 0 },

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
                }, 0 },
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
