using Hotel.WebUI.Models.Stuff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hotel.WebUI.Controllers
{
    public class StuffController : Controller
	{
		private readonly IHttpClientFactory _clientFactory;
        private readonly string _apiAdres = "https://localhost:7064/api/Stuff";
        
        

        public StuffController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
           
        }

        public async Task<IActionResult> Index()
		{
            var client = _clientFactory.CreateClient();
            var response =await client.GetAsync(_apiAdres);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<List<StuffViewModel>>(jsonData);
                return View(model);
            }
            return View();

            
        }
        [HttpGet]
        public async Task<IActionResult> AddStuff()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStuff(StuffViewModel stuff)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(stuff);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json" );
            var response = await client.PostAsync(_apiAdres, stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStuff(Guid id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"_apiAdres/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<StuffViewModel>(jsonData);
                
                value.IsActive = false;
                return View(value);
                //var response = await client.GetAsync($"_apiAdres/{id}");
               
                //var model = JsonConvert.DeserializeObject<StuffViewModel>(jsonData);
                //if (model!=null)
                //{
                //    model.IsActive = false;
                //}                
                //return RedirectToAction(nameof(Index));

            }
            
            //var response = await client.DeleteAsync($"_apiAdres/{id}");
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction(nameof(Index));
            //}

            return View();
        }
    }
}
