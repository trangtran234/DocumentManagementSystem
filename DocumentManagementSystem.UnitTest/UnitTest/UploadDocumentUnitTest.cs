using DocumentManagementSystem.Models;
using DocumentManagementSystem.Services.Interface;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity;

namespace DocumentManagementSystem.UnitTest.UnitTest
{
    [TestFixture]
    public class UploadDocumentUnitTest
    {
        private IUploadService uploadService;

        [OneTimeSetUp]
        public void Init()
        {
            uploadService = UnityConfig.container.Resolve<IUploadService>();
        }

        [TestCaseSource(typeof(Data),"documents")]
        public void AddDocument(Document document, int expected)
        {
            bool actual = uploadService.AddDocument(document);
            bool expectedResult = expected == 1 ? true : false;
            try
            {
                Assert.AreEqual(expectedResult, actual);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [OneTimeTearDown]
        public void Cleanup() { }
    }
}
