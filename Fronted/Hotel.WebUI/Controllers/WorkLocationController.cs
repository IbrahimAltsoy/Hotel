using Hotel.WebUI.Dtos.ContactDto;
using Hotel.WebUI.Dtos.SenderMessageDto;
using Hotel.WebUI.Dtos.WorkLocationDto;
using Hotel.WebUI.Models.Stuff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;
using System.Text;
using static Hotel.WebUI.ToastrMessage.ToastrMessage;

namespace Hotel.WebUI.Controllers
{
    public class WorkLocationController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _apiAdres = "https://localhost:7064/api/WorkLocation";
        private readonly IToastNotification _toastNotification;

        public WorkLocationController(IToastNotification toastNotification, HttpClient httpClient, IHttpClientFactory clientFactory)
        {
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
                var model = JsonConvert.DeserializeObject<List<ResultWorkLocationDto>>(jsonData);
                return View(model);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddWorkLocation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddWorkLocation(CreateWorkLocationDto createWorkLocationDto)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createWorkLocationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_apiAdres, stringContent);
            if (response.IsSuccessStatusCode)
            {
                _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrAddSuccesfull(createWorkLocationDto.Name),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _toastNotification.AddErrorToastMessage(MessajeToastr.ToastrAddUnSuccessfull(createWorkLocationDto.Name),
                        new ToastrOptions
                        {
                            Title = "Başarısız!!!"
                        });
                return View();
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkLocation(Guid id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7064/api/WorkLocation/{id}");
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction(nameof(Index));

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateWorkLocation(Guid id)
        {
            var model = await _httpClient.GetFromJsonAsync<UpdateWorkLocationDto>(_apiAdres + "/" + id);
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateWorkLocation(Guid id, UpdateWorkLocationDto model)
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
