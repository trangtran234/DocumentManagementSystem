using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;

namespace DocumentManagementSystem.WebApp.Controllers
{
    [RoutePrefix("api/upload")]
    public class UploadController : ApiController
    {
        [Route("uploadDocuments")]
        [HttpPost]
        public HttpResponseMessage UploadFiles([FromBody]string message)
        {
            Console.WriteLine("API upload Document.");

            HttpResponseMessage result = new HttpResponseMessage();
            //var httpRequest = HttpContext.Current.Request;
            //var json = httpRequest.Form;
            //Console.WriteLine("Message: " + message);

            //if (httpRequest.Files.Count > 0)
            //{
            //    var docfiles = new List<string>();
            //    foreach (string file in httpRequest.Files)
            //    {
            //        var postedFile = httpRequest.Files[file];
            //        var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
            //        postedFile.SaveAs(filePath);
            //        docfiles.Add(filePath);
            //    }
            //    result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            //}
            //else
            //{
            //    result = Request.CreateResponse(HttpStatusCode.BadRequest);
            //}
            return result;
        }
    }
}
