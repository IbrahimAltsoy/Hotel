using Hotel.WebUI.Dtos.DashboardFollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hotel.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCount:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            //        var client = new HttpClient();
            //        var request = new HttpRequestMessage
            //        {
            //            Method = HttpMethod.Get,
            //            RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofile/drhasanyavuzklinik"),
            //            Headers =
            //{
            //    { "X-RapidAPI-Key", "4ddd0d73e2msh2deded302b847a8p137d79jsn5d2779dcb9f5" },
            //    { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
            //},
            //        };
            //        using (var response = await client.SendAsync(request))
            //        {
            //            response.EnsureSuccessStatusCode();
            //            var body = await response.Content.ReadAsStringAsync();
            //            InstagramFollowersDto instagramFollowersDtos = JsonConvert.DeserializeObject<InstagramFollowersDto>(body);

            //             return View(instagramFollowersDtos);
            //        }

            return View();

        }
    }
}
