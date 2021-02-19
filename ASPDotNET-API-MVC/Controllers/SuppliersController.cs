using API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ASPDotNET_API_MVC.Controllers
{
    public class SuppliersController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44334/API/")
        };

        // GET: Suppliers
        public ActionResult Index()
        {
            IEnumerable<Supplier> supplier = new List<Supplier>();
            var respondTask = client.GetAsync("Suppliers");
            respondTask.Wait();
            var result = respondTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                supplier = readTask.Result;
            }
            else
            {
                ReadFeedback(result);
            }

            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            ViewBag.WarningMessage = TempData["WarningMessage"];

            return View(supplier);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            Supplier supplier = new Supplier();
            var respondTask = client.GetAsync("Suppliers" + "/" + id);
            respondTask.Wait();
            var result = respondTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                supplier = readTask.Result.FirstOrDefault(e => e.SupplierId == id);
            }
            else
            {
                ReadFeedback(result);
            }
            return View(supplier);
        }

        public ActionResult Details(int id)
        {
            Supplier supplier = new Supplier();
            var respondTask = client.GetAsync("Suppliers" + "/" + id);
            respondTask.Wait();
            var result = respondTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                supplier = readTask.Result.FirstOrDefault(e => e.SupplierId == id);
            }
            else
            {
                ReadFeedback(result);
            }
            return View(supplier);
        }

        public ActionResult Delete(int id)
        {
            Supplier supplier = new Supplier();
            var respondTask = client.GetAsync("Suppliers" + "/" + id);
            respondTask.Wait();
            var result = respondTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Supplier>>();
                readTask.Wait();
                supplier = readTask.Result.FirstOrDefault(e => e.SupplierId == id);
            }
            else
            {
                ReadFeedback(result);
            }
            return View(supplier);
        }

        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {
            HttpResponseMessage result = client.PostAsJsonAsync("Suppliers", supplier).Result;
            ReadFeedback(result);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Supplier supplier)
        {
            HttpResponseMessage result = client.PutAsJsonAsync("Suppliers/" + supplier.SupplierId, supplier).Result;
            ReadFeedback(result);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(Supplier supplier, int id)
        {
            HttpResponseMessage result = client.DeleteAsync("Suppliers/" + id).Result;
            ReadFeedback(result);
            return RedirectToAction("Index");
        }

        private void ReadFeedback(HttpResponseMessage result)
        {

            var readTask = result.Content.ReadAsStringAsync();
            readTask.Wait();
            var jsonString = readTask.Result;
            var message = JsonConvert.DeserializeObject<VM_Message>(jsonString);

            if (result.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = message.Message;
            }
            else
            {
                TempData["WarningMessage"] = message.Message;
            }
        }


    }
}