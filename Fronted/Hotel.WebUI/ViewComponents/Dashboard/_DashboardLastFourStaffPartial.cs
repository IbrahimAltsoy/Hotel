using Hotel.WebUI.Dtos.AboutDto;
using Hotel.WebUI.Dtos.StuffDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hotel.WebUI.ViewComponents.Dashboard
{
    public class _DashboardLastFourStaffPartial:ViewComponent
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _clientFactory;



        public _DashboardLastFourStaffPartial(HttpClient httpClient, IHttpClientFactory clientFactory)
        {

            _httpClient = httpClient;
            _clientFactory = clientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7064/api/Stuff/StuffLastFour");
            if (response.IsSuccessStatusCode)
            {

                var jsonData = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<List<ResultStuffDto>>(jsonData);
                return View(model);
            }
            return View();
        }
    }
}
