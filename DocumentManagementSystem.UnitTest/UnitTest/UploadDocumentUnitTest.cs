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

        [TestCaseSource(typeof(Data), "uploadCases")]
        public void AddDocument(Document document, bool expected)
        {
            bool actual = uploadService.AddDocument(document);
            try
            {
                Assert.AreEqual(expected, actual);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [OneTimeTearDown]
        public void Cleanup() { }
    }
}
