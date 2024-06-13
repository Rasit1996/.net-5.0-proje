using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ApiController : Controller
    {
        HttpClient client = new HttpClient();
        public async Task< IActionResult> Index()
        {
            
            HttpResponseMessage response =await client.GetAsync("https://localhost:44384/api/Default");
            string json=await response.Content.ReadAsStringAsync();
             List<Personel> liste =JsonConvert.DeserializeObject<List<Personel>>(json);
            return View(liste);
        }
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult > Ekle(Personel p)
        {
           string json=  JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(json,Encoding.UTF8,"application/json");
            HttpResponseMessage response = await client.PostAsync("https://localhost:44384/api/Default", content);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
  
        }

        public async Task<IActionResult> guncelle(int id)
        {
            string url = "https://localhost:44384/api/Default/" + id;
            HttpResponseMessage response =await client.GetAsync(url);
            string json= await response.Content.ReadAsStringAsync();
            Personel p=JsonConvert.DeserializeObject<Personel>(json);
            if(response.IsSuccessStatusCode)
            {
                return View(p);
            }
            return RedirectToAction("Index");
            
                
        }

        [HttpPost]
        public async Task<IActionResult> guncelle(Personel p)
        {
            string json=JsonConvert.SerializeObject(p);
            StringContent content= new StringContent(json,Encoding.UTF8,"application/json");
            HttpResponseMessage response=await client.PutAsync("https://localhost:44384/api/Default", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> sil(int id)
        {
            string Url = "https://localhost:44384/api/Default/" + id;
            HttpResponseMessage response=await client.DeleteAsync(Url);
          
                return RedirectToAction("Index");
           

        }
    }

    
     
    public class Personel
    {
        public int ID { get; set; }
        public string  Adi { get; set; }

    }
}
