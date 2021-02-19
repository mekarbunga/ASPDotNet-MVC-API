using API.Models;
using API.Repositories;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class SuppliersController : ApiController
    {
        SupplierRepository supplierRepository = new SupplierRepository();
        MessageFactory message = new MessageFactory();

        public IHttpActionResult Post(Supplier supplier)
        {
            int result = supplierRepository.Create(supplier);
            return message.Message(result);
        }

        public IHttpActionResult Put(Supplier supplier, int id)
        {
            int result = supplierRepository.Update(supplier, id);
            return message.Message(result);
        }

        public IHttpActionResult Get()
        {
            var actionResult = supplierRepository.Get();
            var isEmpty = false;
            foreach (var item in actionResult)
            {
                if (item.SupplierId == 0)
                {
                    isEmpty = true;
                    break;
                }
            }
            if (isEmpty)
                return BadRequest("Data is empty");
            else
                return Ok(actionResult);
        }


        public async Task<IHttpActionResult> Get(int id)
        {
            var actionResult = await supplierRepository.Get(id);
            var isEmpty = false;
            foreach (var item in actionResult)
            {
                if (item.SupplierId == 0)
                {
                    isEmpty = true;
                    break;
                }
            }
            if (isEmpty)
                return BadRequest("Data cannot be found");
            else
                return Ok(actionResult);
        }

        public IHttpActionResult Delete(int id)
        {
            int result = supplierRepository.Delete(id);
            return message.Message(result);
        }
    }
}
