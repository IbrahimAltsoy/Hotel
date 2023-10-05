using Hotel.WebUI.Dtos.RoomDto;
using Hotel.WebUI.Models.Stuff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;

namespace Hotel.WebUI.ViewComponents.UI
{
    public class _UIRoomStart:ViewComponent
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _apiAdres = "https://localhost:7064/api/Room";
        

        public _UIRoomStart(HttpClient httpClient, IHttpClientFactory clientFactory)
        {
           
            _httpClient = httpClient;
            _clientFactory = clientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(_apiAdres);
            if (response.IsSuccessStatusCode)
            {

                var jsonData = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData);
                return View(model.Take(3).ToList());
            }
            return View();
        }
    }
}
