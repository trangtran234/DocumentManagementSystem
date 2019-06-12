using DocumentManagementSystem.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentManagementSystem.UnitTest
{
    [TestFixture]
    public class Testcase
    {
        private readonly IDocumentService documentService;

        public Testcase(IDocumentService documentService)
        {
            this.documentService = documentService;
        }
    }
}
