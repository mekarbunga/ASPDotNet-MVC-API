using API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    public class MessageFactory : ApiController
    {
        public IHttpActionResult Message(int result)
        {
            VM_Message message = new VM_Message();
            HttpStatusCode statusCode;
            if (result > 0)
            {
                statusCode = HttpStatusCode.OK;
                message.Message = "Successful!";
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                message.Message = "Action failed";
            }

            string jsonString = JsonConvert.SerializeObject(message);
            return ResponseMessage(Request.CreateResponse(statusCode, jsonString , JsonMediaTypeFormatter.DefaultMediaType));
        }

        public IHttpActionResult Message(int result, List<Supplier> list)
        {
            VM_Message message = new VM_Message();
            HttpStatusCode statusCode;
            string jsonString
            if (result > 0)
            {
                statusCode = HttpStatusCode.OK;
                jsonString = JsonConvert.SerializeObject(list);
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
                message.Message = "Action failed";
                jsonString = JsonConvert.SerializeObject(list);
            }

            
            return ResponseMessage(Request.CreateResponse(statusCode, jsonString, JsonMediaTypeFormatter.DefaultMediaType));
        }
    }
}