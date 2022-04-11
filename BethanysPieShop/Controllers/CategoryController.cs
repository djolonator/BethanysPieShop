using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.Controllers
{
    public class CategoryController : Controller
    {
       

        Uri baseAddress = new Uri("https://localhost:44337/api");
        HttpClient client;
        
        public CategoryController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {

            List<CategoryViewModel> modelList = new List<CategoryViewModel>();
            
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/categories").Result;
           
            string data = response.Content.ReadAsStringAsync().Result;
           
            modelList = JsonConvert.DeserializeObject<List<CategoryViewModel>>(data);

            return View(modelList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/Json");

            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/categories", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            
            return View();
        }

        public IActionResult Edit(int id)
        {
            CategoryViewModel model = new CategoryViewModel();
            //method no allowed , mozda jer ga nema, namestiti
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/categories/"+id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                model = JsonConvert.DeserializeObject<CategoryViewModel>(data);
            }
            
            // ovako vraca view sa modela create
            return View("Create", model);
        }

        [HttpPost]
        public IActionResult Edit(CategoryViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/categories/" + model.CategoryId, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Create", model);
        }

        [HttpDelete]

         [Route("api/categories/{categoryId}")] 
        public IActionResult Delete(int id)
        {
            HttpResponseMessage response =  client.DeleteAsync(client.BaseAddress + "/categories?id=" + id).Result;

            return RedirectToAction("Index");
        }
    }
}
