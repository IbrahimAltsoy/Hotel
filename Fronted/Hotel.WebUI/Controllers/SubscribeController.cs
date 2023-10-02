using Hotel.WebUI.Dtos.RoomDto;
using Hotel.WebUI.Dtos.Subscribe;
using Hotel.WebUI.Dtos.UINewsLetterStart;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using static Hotel.WebUI.ToastrMessage.ToastrMessage;

namespace Hotel.WebUI.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _apiAdres = "https://localhost:7064/api/Subscribe";
        private readonly IToastNotification _toastNotification;

        public SubscribeController(IToastNotification toastNotification, HttpClient httpClient, IHttpClientFactory clientFactory)
        {
            _toastNotification = toastNotification;
            _httpClient = httpClient;
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<ResultSubscribeDto>>(_apiAdres);
            return View(model);
        }
        public async Task<ActionResult> AddSubscribe()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddSubscribe(Create_SubscribeDto create)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var response = await _httpClient.PostAsJsonAsync(_apiAdres, create);
                    if (response.IsSuccessStatusCode)
                    {
                        _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrAddSuccesfull("Başarılı"),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                        return RedirectToAction(nameof(Index));
                    }

                }
                catch
                {
                    _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrAddUnSuccessfull("Başarısız"),
                        new ToastrOptions
                        {
                            Title = "Başarısız"
                        });
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(create);
        }
        public async Task<ActionResult> UpdateSubscribe(Guid id)
        {
            var model = await _httpClient.GetFromJsonAsync<UpdateSubscribeDto>(_apiAdres + "/" + id);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateSubscribe(Guid id, UpdateSubscribeDto update)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _httpClient.PutAsJsonAsync(_apiAdres + "/" + id, update);
                    if (response.IsSuccessStatusCode)
                    {
                        _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrUpdateSuccesfull("Başarılı"),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                        return RedirectToAction(nameof(Index));
                    }

                }
                catch
                {
                    _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrUpdateUnSuccessfull("Başarısız"),
                        new ToastrOptions
                        {
                            Title = "Başarısız"
                        });
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(update);
        }
        public async Task<ActionResult> MoveToSubscribe(Guid id)
        {
            var model = await _httpClient.GetFromJsonAsync<MoveToArcihiveSubscribeDto>(_apiAdres + "/" + id);
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> MoveToSubscribe(Guid id, MoveToArcihiveSubscribeDto subscribeDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _httpClient.PutAsJsonAsync(_apiAdres + "/" + id, subscribeDto);
                    if (response.IsSuccessStatusCode)
                    {
                        _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrUpdateSuccesfull("Oldu"),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                        return RedirectToAction(nameof(Index));
                    }

                }
                catch
                {
                    _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrUpdateUnSuccessfull("Olmadı"),
                        new ToastrOptions
                        {
                            Title = "Başarısız"
                        });
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(subscribeDto);
        }

    }
}
