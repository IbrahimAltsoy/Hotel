using Hotel.EntitiyLayer.Concreate;
using Hotel.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Drawing.Drawing2D;
using static Hotel.WebUI.ToastrMessage.ToastrMessage;

namespace Hotel.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres = "https://localhost:7064/api/Service";
        private readonly IToastNotification _toastNotification;

        public ServiceController(HttpClient httpClient, IToastNotification toastNotification)
        {
            _httpClient = httpClient;
            _toastNotification = toastNotification;
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
                    if (response.IsSuccessStatusCode)
                    {
                        _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrAddSuccesfull(serviceDto.Title),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                        return RedirectToAction(nameof(Index));
                    }
                        
                }
                catch
                {
                    _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrAddUnSuccessfull(serviceDto.Title),
                        new ToastrOptions
                        {
                            Title = "Başarısız"
                        });
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
                    if (response.IsSuccessStatusCode)
                    {
                        _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrUpdateSuccesfull(updateService.Title),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                        return RedirectToAction(nameof(Index));
                    }
                        
                }
                catch
                {
                    _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrUpdateUnSuccessfull(updateService.Title),
                        new ToastrOptions
                        {
                            Title = "Başarısız"
                        });
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
