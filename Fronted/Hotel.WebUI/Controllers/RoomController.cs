using Hotel.WebUI.Dtos.RoomDto;
using Hotel.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Hotel.WebUI.Controllers
{
    public class RoomController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres = "https://localhost:7064/api/Room";
        private readonly IToastNotification _toastNotification;

        public RoomController(IToastNotification toastNotification, HttpClient httpClient)
        {
            _toastNotification = toastNotification;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<ResultRoomDto>>(_apiAdres);     
            return View(model);
        }
    }
}
