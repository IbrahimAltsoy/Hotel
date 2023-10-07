using Hotel.DtoLayer.Dtos.AboutDto;
using Hotel.EntitiyLayer.Concreate;
using Hotel.WebUI.Models.Stuff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;

namespace Hotel.WebUI.ViewComponents.UI
{
    public class _UIAboutStart:ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres = "https://localhost:7064/api/About";
        private readonly IToastNotification _toastNotification;
        public _UIAboutStart(IHttpClientFactory clientFactory, HttpClient httpClient, IToastNotification toastNotification)
        {
            _clientFactory = clientFactory;
            _httpClient = httpClient;
            _toastNotification = toastNotification;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(_apiAdres);
            if (response.IsSuccessStatusCode)
            {

                var jsonData = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<List<AddAboutDto>>(jsonData);
                return View(model.Take(1).ToList());
            }
            return View();
        }
    }
}
