using Hotel.WebUI.Models.Stuff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;
using static Hotel.WebUI.ToastrMessage.ToastrMessage;
using System.Text;
using Hotel.WebUI.Dtos.CategoryMessage;
using Microsoft.CodeAnalysis.Options;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hotel.WebUI.Controllers
{
    
    public class CategoryMessageController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres = "https://localhost:7064/api/CategoryMessage";
        private readonly IToastNotification _toastNotification;

        public CategoryMessageController(IHttpClientFactory clientFactory, HttpClient httpClient, IToastNotification toastNotification)
        {
            _clientFactory = clientFactory;
            _httpClient = httpClient;
            _toastNotification = toastNotification;

        }
        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(_apiAdres);
            if (response.IsSuccessStatusCode)
            {

                var jsonData = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<List<ResultCategoryMessage>>(jsonData);
                return View(model);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddCategoryMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategoryMessage(CreateCategoryMessageDto categoryMessageDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(categoryMessageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_apiAdres, stringContent);
            if (response.IsSuccessStatusCode)
            {
                _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrAddSuccesfull(categoryMessageDto.Name),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _toastNotification.AddErrorToastMessage(MessajeToastr.ToastrAddUnSuccessfull(categoryMessageDto.Name),
                        new ToastrOptions
                        {
                            Title = "Başarısız!!!"
                        });
                return View();
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryMessage(Guid id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7064/api/CategoryMessage/{id}");
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction(nameof(Index));

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategoryMessage(Guid id)
        {
            var model = await _httpClient.GetFromJsonAsync<UpdateCategoryMessage>(_apiAdres + "/" + id);
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategoryMessage(Guid id, UpdateCategoryMessage model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cevap = await _httpClient.PutAsJsonAsync(_apiAdres + "/" + id, model);
                    if (cevap.IsSuccessStatusCode)
                    {
                        _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrUpdateSuccesfull(model.Name),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                        return RedirectToAction(nameof(Index));
                    }

                }
                catch
                {
                    _toastNotification.AddErrorToastMessage(MessajeToastr.ToastrUpdateUnSuccessfull(model.Name),
                        new ToastrOptions
                        {
                            Title = "Başarısız!!!"
                        });
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(model);
        }
    }
}
