using Hotel.BusinessLayer.Abstract;
using Hotel.WebUI.Dtos.AboutDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;
using static Hotel.WebUI.ToastrMessage.ToastrMessage;
using System.Text;

namespace Hotel.WebUI.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _apiAdres = "https://localhost:7064/api/About";
        private readonly IToastNotification _toastNotification;
       // private readonly IBookingService _bookingService;

        public AdminAboutController(IToastNotification toastNotification, HttpClient httpClient, IHttpClientFactory clientFactory)
        {
           // _bookingService = bookingService;
            _toastNotification = toastNotification;
            _httpClient = httpClient;
            _clientFactory = clientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(_apiAdres);
            if (response.IsSuccessStatusCode)
            {

                var jsonData = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(model);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAbout(CreateAboutDto about)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(about);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_apiAdres, stringContent);
            if (response.IsSuccessStatusCode)
            {
                _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrAddSuccesfull(about.Title1),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _toastNotification.AddErrorToastMessage(MessajeToastr.ToastrAddUnSuccessfull(about.Title1),
                        new ToastrOptions
                        {
                            Title = "Başarısız!!!"
                        });
                return View();
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(Guid id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7064/api/About/{id}");
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction(nameof(Index));

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(Guid id)
        {
            var model = await _httpClient.GetFromJsonAsync<UpdateAboutDto>(_apiAdres + "/" + id);
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(Guid id, UpdateAboutDto model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cevap = await _httpClient.PutAsJsonAsync(_apiAdres + "/" + id, model);
                    if (cevap.IsSuccessStatusCode)
                    {
                        _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrUpdateSuccesfull(model.Title1),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                        return RedirectToAction(nameof(Index));
                    }

                }
                catch
                {
                    _toastNotification.AddErrorToastMessage(MessajeToastr.ToastrUpdateUnSuccessfull(model.Title1),
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
