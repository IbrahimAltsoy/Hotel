using Hotel.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;

namespace Hotel.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres = "https://localhost:7064/api/Service";

        public ServiceController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<ResultServiceDto>>(_apiAdres);
            return View(model);
        }
        public async Task<ActionResult> AddService()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddService(CreateServiceDto serviceDto)
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    
                    var response = await _httpClient.PostAsJsonAsync(_apiAdres, serviceDto); 
                    if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index)); 
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(serviceDto);
        }
        public async Task<ActionResult> UpdateService(Guid id)
        {
            var model = await _httpClient.GetFromJsonAsync<UpdateServiceDto>(_apiAdres + "/" + id);
            return View(model);
        }
                
        [HttpPost]       
        public async Task<ActionResult> UpdateService(Guid id, UpdateServiceDto updateService)
        {
            if (ModelState.IsValid)
            {
                try
                {                   
                    var response = await _httpClient.PutAsJsonAsync(_apiAdres + "/" + id, updateService);
                    if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(updateService);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(Guid id)
        {
            var model = await _httpClient.GetFromJsonAsync<DeleteServiceDto>(_apiAdres + "/" + id);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> DeleteService(Guid id, DeleteServiceDto deleteService)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _httpClient.PostAsJsonAsync(_apiAdres + "/" + id, deleteService);
                    if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(deleteService);
        }
    }
}
