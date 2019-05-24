using DocumentManagementSystem.Models;
using DocumentManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DocumentManagementSystem.WebApp.Controllers
{
    [RoutePrefix("api/documentterms")]
    public class DocumentTermsController : ApiController
    {
        private IDocumentTermService documentTermService;

        public DocumentTermsController(DocumentTermService documentTermService)
        {
            this.documentTermService = documentTermService;
        }

        [Route("DocumentTerms")]
        [HttpGet]
        public List<DocumentTerm> GetAllDocumentTerms()
        {
            return documentTermService.GetAllDocumentTerms();
        }
    }
}
