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

        //[Route("uploadDocuments")]
        //[HttpPost]
        //public HttpResponseMessage UploadFiles(object[] message)
        //{
        //    List<Document> listDocuments = new List<Document>();
        //    for(int i =0; i < message.Count(); i++)
        //    {
        //        dynamic json = JObject.Parse(message[i].ToString());

        //        Document document = new Document();
        //        document.DocumentName = json.documentName;
        //        document.DocumentSize = json.documentSize;
        //        document.DocumentType = json.documentType;
        //        document.Created = json.created;
        //        document.LastModified = json.created;

        //        BinaryFormatter bf = new BinaryFormatter();
        //        MemoryStream ms = new MemoryStream();
        //        bf.Serialize(ms, json.documentContent);
        //        document.DocumentContent = ms.ToArray();

        //        //document.DocumentContent = (byte[])json.documentContent;
        //        //document.DocumentContent = json.documentContent;

        //        listDocuments.Add(document);
        //    }

        //    documentServices.AddListDocument(listDocuments);

        //    HttpResponseMessage result = new HttpResponseMessage();
        //    return result;
        //}

        [HttpPost]
        [Route("uploadDocuments")]
        public async Task<HttpResponseMessage> Post()
        {
            //if (!Request.Content.IsMimeMultipartContent())
            //{
            //    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            //}

            var root = HttpContext.Current.Server.MapPath("~/App_Data/Uploadfiles");
            Directory.CreateDirectory(root);
            var provider = new MultipartFormDataStreamProvider(root);
            var result = await Request.Content.ReadAsMultipartAsync(provider);


            //var model = result.FormData["jsonData"];
            //if (model == null)
            //{
            //    throw new HttpResponseException(HttpStatusCode.BadRequest);
            //}
            //TODO: Do something with the JSON data.  

            //get the posted files  
            foreach (var file in result.FileData)
            {
                //TODO: Do something with uploaded file.  
            }

            return Request.CreateResponse(HttpStatusCode.OK, "success!");
        }
    }
}
