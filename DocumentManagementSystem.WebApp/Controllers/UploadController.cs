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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            List<Document> listFail = new List<Document>();
            List<Document> listSuccess = new List<Document>();
            ICollection<DocumentType> documentTypes = new List<DocumentType>();

            var root = HttpContext.Current.Server.MapPath("~/App_Data/Uploadfiles");
            Directory.CreateDirectory(root);
            var provider = new MultipartFormDataStreamProvider(root);
            var result = await Request.Content.ReadAsMultipartAsync(provider);

            var parentID = HttpContext.Current.Request.Form["parentID"];
            var typeID = HttpContext.Current.Request.Form["typeID"];
            dynamic stuff = JsonConvert.DeserializeObject(typeID); 

            foreach( var s in stuff)
            {
                DocumentType documentType = new DocumentType();
                documentType.Id = s.id;
                documentType.Type = s.type;
                documentTypes.Add(documentType);
            }

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
                document.ParentId = Convert.ToInt16(parentID);
                document.DocumentTypes = documentTypes;

                listDocument.Add(document);

            }

            foreach(Document document in listDocument)
            {
                bool flag = documentServices.AddDocument(document);
                if (flag)
                {
                    listSuccess.Add(document);
                }
                else
                {
                    listFail.Add(document);
                }
            }

            if (listSuccess.Count != 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, listSuccess);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, listFail);
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