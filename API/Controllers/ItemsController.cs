using API.Models;
using API.Repositories;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class ItemsController : ApiController
    {
        ItemRepository itemRepository = new ItemRepository();
        public IHttpActionResult Post(Item item)
        {
            int result = itemRepository.Create(item);
            if (result < 1)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Create failed"));
            }
            else
            {
                return Ok();
            }
        }

        public IHttpActionResult Put(Item item, int id)
        {
            int result = itemRepository.Update(item, id);
            if (result < 1)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Update failed"));
            }
            else
            {
                return Ok();
            }
        }

        public IHttpActionResult Get()
        {
            HttpStatusCode statusCode = new HttpStatusCode();
            var response = new JArray();
            try
            {
                var actionResult = itemRepository.Get();
                Supplier supplier = new Supplier();

                response = JArray.FromObject(actionResult);
                statusCode = HttpStatusCode.OK;

            }
            catch (Exception ex)
            {
                {
                    statusCode = HttpStatusCode.InternalServerError;
                    string jsonString = "[{\"ServerMessage\": \"" + ex.GetType().Name + "\"}]";
                    response = JArray.Parse(jsonString);
                }
            }
            return ResponseMessage(Request.CreateResponse(statusCode, response, JsonMediaTypeFormatter.DefaultMediaType));
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            HttpStatusCode statusCode = new HttpStatusCode();
            var response = new JArray();
            try
            {
                var actionResult = await itemRepository.Get(id);
                response = JArray.FromObject(actionResult);
                statusCode = HttpStatusCode.OK;

            }
            catch (Exception ex)
            {
                {
                    statusCode = HttpStatusCode.InternalServerError;
                    string jsonString = "[{\"ServerMessage\": \"" + ex.GetType().Name + "\"}]";
                    response = JArray.Parse(jsonString);
                }
            }
            return ResponseMessage(Request.CreateResponse(statusCode, response));
        }

        public IHttpActionResult Delete(int id)
        {
            int result = itemRepository.Delete(id);
            if (result < 1)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Update failed"));
            }
            else
            {
                return Ok();
            }
        }
    }
}
