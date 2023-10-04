using Hotel.BusinessLayer.Abstract;
using Hotel.DtoLayer.Dtos.BookingDto;
using Hotel.WebUI.Dtos.BookingDto;
using Hotel.WebUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using static Hotel.WebUI.ToastrMessage.ToastrMessage;

namespace Hotel.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _apiAdres = "https://localhost:7064/api/Booking";
        private readonly IToastNotification _toastNotification;
        private readonly IBookingService _bookingService;

        public BookingAdminController(IToastNotification toastNotification, HttpClient httpClient, IHttpClientFactory clientFactory, IBookingService bookingService)
        {
            _bookingService= bookingService;
            _toastNotification = toastNotification;
            _httpClient = httpClient;
            _clientFactory = clientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<ResultBookingAdminDto>>(_apiAdres);
            return View(model);
        }
        
        public async Task<IActionResult> UpdateBookingStatus(Guid id)
        {            
            await _bookingService.BookingStatusChangeApproved(id);

            _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrUpdateSuccesfull("Rezervasyon başarılı ile güncellendi"),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
            return Redirect("/BookingAdmin/Index/");
            
        }
        //public async Task<IActionResult> ChangeToTrue(Guid id)
        //{

        //    var model = await _guideService.GuidesstatuChangeToTrue(id);


        //    return Redirect("/Admin/Guide/Index/");
        //}

    }
}
