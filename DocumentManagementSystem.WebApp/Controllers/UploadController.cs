using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using DocumentManagementSystem.Models;
using DocumentManagementSystem.Services;

namespace DocumentManagementSystem.WebApp.Controllers
{
    [RoutePrefix("api/upload")]
    public class UploadController : ApiController
    {
        private IDocumentService documentServices;

        public UploadController(IDocumentService documentServices)
        {
            this.documentServices = documentServices;
        }

        [HttpPost]
        [Route("uploadDocuments")]
        public async Task<HttpResponseMessage> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            List<Document> listDocument = new List<Document>();
            List<Document> listLimitedSize = new List<Document>();

            var root = HttpContext.Current.Server.MapPath("~/App_Data/Uploadfiles");
            Directory.CreateDirectory(root);
            var provider = new MultipartFormDataStreamProvider(root);
            var result = await Request.Content.ReadAsMultipartAsync(provider);

            foreach (var file in result.FileData)
            {
                Document document = new Document();
                byte[] buff = null;

                FileStream fs = new FileStream(file.LocalFileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                long numBytes = new FileInfo(file.LocalFileName).Length;
                buff = br.ReadBytes((int)numBytes);

                document.DocumentContent = File.ReadAllBytes(file.LocalFileName);
                document.DocumentName = file.Headers.ContentDisposition.FileName.Replace("\"", string.Empty);
                document.DocumentSize = document.DocumentContent.Length;
                document.CreateByID = 1;
                document.LastModifiedByID = 1;
                document.ParentId = 21;


                if (document.DocumentSize > Common.LIMITED_FILE_SIZE)
                {
                    listLimitedSize.Add(document);
                }
                listDocument.Add(document);

            }

            if (listLimitedSize.Count != 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Check File Size " + listLimitedSize);
            }

            List<Document> listDocumentsSuccess = documentServices.AddListDocument(listDocument);
            if (listDocumentsSuccess.Count != 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, listDocumentsSuccess);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        [Route("deleteDocument")]
        public HttpResponseMessage DeleteDocument(int id)
        {
            documentServices.DeleteDocument(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}