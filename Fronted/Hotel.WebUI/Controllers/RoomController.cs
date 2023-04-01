using Hotel.WebUI.Dtos.RoomDto;
using Hotel.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using static Hotel.WebUI.ToastrMessage.ToastrMessage;

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
        public async Task<ActionResult> AddRoom()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddRoom(CreateRoomDto createRoom)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var response = await _httpClient.PostAsJsonAsync(_apiAdres, createRoom);
                    if (response.IsSuccessStatusCode)
                    {
                        _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrAddSuccesfull(createRoom.Title),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                        return RedirectToAction(nameof(Index));
                    }

                }
                catch
                {
                    _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrAddUnSuccessfull(createRoom.Title),
                        new ToastrOptions
                        {
                            Title = "Başarısız"
                        });
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(createRoom);
        }
        public async Task<ActionResult> UpdateRoom(Guid id)
        {
            var model = await _httpClient.GetFromJsonAsync<UpdateRoomDto>(_apiAdres + "/" + id);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateRoom(Guid id, UpdateRoomDto updateRoom)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _httpClient.PutAsJsonAsync(_apiAdres + "/" + id, updateRoom);
                    if (response.IsSuccessStatusCode)
                    {
                        _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrUpdateSuccesfull(updateRoom.Title),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                        return RedirectToAction(nameof(Index));
                    }

                }
                catch
                {
                    _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrUpdateUnSuccessfull(updateRoom.Title),
                        new ToastrOptions
                        {
                            Title = "Başarısız"
                        });
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(updateRoom);
        }
    }

}
