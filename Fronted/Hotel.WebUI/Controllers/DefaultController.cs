using Hotel.DtoLayer.Dtos.AboutDto;
using Hotel.WebUI.Dtos.UINewsLetterStart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;
using static Hotel.WebUI.ToastrMessage.ToastrMessage;

namespace Hotel.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres = "https://localhost:7064/api/Subscribe";
        private readonly IToastNotification _toastNotification;
        public DefaultController(IHttpClientFactory clientFactory, HttpClient httpClient, IToastNotification toastNotification)
        {
            _clientFactory = clientFactory;
            _httpClient = httpClient;
            _toastNotification = toastNotification;

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet] 
        public PartialViewResult CreateSubscribe()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSubscribe(Create_SubscribeDto subscribeDto)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var response = await _httpClient.PostAsJsonAsync(_apiAdres, subscribeDto);
                    if (response.IsSuccessStatusCode)
                    {
                        _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrAddSuccesfull("Tebrikler Abone oldunuz!!"),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                        return RedirectToAction(nameof(Index));
                    }

                }
                catch
                {
                    _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrAddUnSuccessfull("Malesef Abone olamadınız"),
                        new ToastrOptions
                        {
                            Title = "Başarısız"
                        });
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(subscribeDto);
        }
        public IActionResult ErrorNumber(int errorNumber)
        {

            return View();
        }
    }
}
