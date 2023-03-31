using Hotel.WebUI.Models.Stuff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;
using System.Text;
using static Hotel.WebUI.ToastrMessage.ToastrMessage;

namespace Hotel.WebUI.Controllers
{
    public class StuffController : Controller	{
		private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres = "https://localhost:7064/api/Stuff";
        private readonly IToastNotification _toastNotification;

        public StuffController(IHttpClientFactory clientFactory, HttpClient httpClient, IToastNotification toastNotification)
        {
            _clientFactory = clientFactory;
            _httpClient = httpClient;
            _toastNotification = toastNotification;
     
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
                _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrAddSuccesfull(stuff.Name),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _toastNotification.AddErrorToastMessage(MessajeToastr.ToastrAddUnSuccessfull(stuff.Name),
                        new ToastrOptions
                        {
                            Title = "Başarısız!!!"
                        });
                return View();
            }
            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStuff(Guid id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7064/api/Stuff/{id}");
            if (response.IsSuccessStatusCode)
            {                  
                
                return RedirectToAction(nameof(Index));              

            }          
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateStuff(Guid id)
        {
            var model = await _httpClient.GetFromJsonAsync<UpdateStuffViewModel>(_apiAdres + "/" + id);
            return View(model);
           
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStuff(Guid id,UpdateStuffViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {                    
                    var cevap = await _httpClient.PutAsJsonAsync(_apiAdres + "/" + id, model);
                    if (cevap.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(model);           
        }

    }
}
