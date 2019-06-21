using DocumentManagementSystem.IRepository;
using DocumentManagementSystem.Models;
using DocumentManagementSystem.Services.Interface;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity;
using System.Linq;
using DocumentManagementSystem.Services.Implement;

namespace DocumentManagementSystem.UnitTest.UnitTest
{
    [TestFixture]
    public class UploadDocumentUnitTest
    {
        private IUploadService uploadService;
        private IDocumentRepository documentRepository;

        [OneTimeSetUp]
        public void Init()
        {
            uploadService = UnityConfig.container.Resolve<IUploadService>();
            documentRepository = Substitute.For<IDocumentRepository>();
        }

        [TestCaseSource(typeof(Data), "uploadCases")]
        public void AddDocument(Document document, bool expected)
        {
            documentRepository.AddDocument(document, document.DocumentTypes.ToList()).ReturnsForAnyArgs(expected);
            uploadService = new UploadService(documentRepository);

            bool actual = uploadService.AddDocument(document);
            try
            {
                Assert.AreEqual(expected, actual);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [OneTimeTearDown]
        public void Cleanup() { }
    }
}
