using API.Models;
using API.Repositories;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class SuppliersController : ApiController
    {
        SupplierRepository supplierRepository = new SupplierRepository();
        VM_Message message = new VM_Message();
        public IHttpActionResult Post(Supplier supplier)
        {
            int result = supplierRepository.Create(supplier);
            if (result > 0) 
            {
                message.Message = "Data was succesfully created";
                return Ok(message);
            }
            else 
            {
                return BadRequest("Data creation failed");
            }
        }

        public IHttpActionResult Put(Supplier supplier, int id)
        {
            int result = supplierRepository.Update(supplier, id);
            if (result > 0)
            {
                message.Message = "Data was succesfully edited";
                return Ok(message);
            }
            else
                return BadRequest("Data update failed");
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
            if (result > 0)
            {
                message.Message = "Data was succesfully deleted";
                return Ok(message);
            }
            else
                return BadRequest("Data deletion failed");
        }
    }
}
