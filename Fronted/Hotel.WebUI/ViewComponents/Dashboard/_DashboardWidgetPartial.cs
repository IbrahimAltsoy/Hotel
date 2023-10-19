using Hotel.WebUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hotel.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _clientFactory;
        


        public _DashboardWidgetPartial(HttpClient httpClient, IHttpClientFactory clientFactory)
        {

            _httpClient = httpClient;
            _clientFactory = clientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7064/api/DashboardWidget/StuffCount");
            if (response.IsSuccessStatusCode)
            {

                var jsonData = await response.Content.ReadAsStringAsync();
                
                ViewBag.StaffCount = jsonData;
            }
            var client2 = _clientFactory.CreateClient();
            var response2 = await client.GetAsync("https://localhost:7064/api/DashboardWidget/GetBookingCount");
            if (response2.IsSuccessStatusCode)
            {

                var jsonData2 = await response.Content.ReadAsStringAsync();
                
                ViewBag.BookingCount = jsonData2;
            }
            var client3 = _clientFactory.CreateClient();
            var response3 = await client.GetAsync("https://localhost:7064/api/DashboardWidget/AppUserCount");
            if (response3.IsSuccessStatusCode)
            {

                var jsonData3 = await response3.Content.ReadAsStringAsync();
                
                ViewBag.UserCount = jsonData3;
            }
            var client4 = _clientFactory.CreateClient();
            var response4 = await client.GetAsync("https://localhost:7064/api/DashboardWidget/GetBookingCount");
            if (response4.IsSuccessStatusCode)
            {

                var jsonData4 = await response4.Content.ReadAsStringAsync();

                ViewBag.RoomCount = jsonData4;
            }
            return View();
        }
    }
}
