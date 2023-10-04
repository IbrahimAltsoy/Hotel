using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RapidApiConsume.Models
{
    public class BookingExcahngeApiController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<BookingExcahngeApiViewModel> bookingExcahnges = new List<BookingExcahngeApiViewModel>();


            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=tl"),
                Headers =
    {
        { "X-RapidAPI-Key", "4ddd0d73e2msh2deded302b847a8p137d79jsn5d2779dcb9f5" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                var values = JsonConvert.DeserializeObject<BookingExcahngeApiViewModel>(body);

                return View(values.exchange_rates.ToList());
            }


        }
    }
}
