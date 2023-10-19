using Hotel.WebUI.Dtos.DashboardFollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hotel.WebUI.ViewComponents.Dashboard
{
    public class _DashboardTwitterFollowersPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter241.p.rapidapi.com/user?username=muzikjen"),
                Headers =
    {
        { "X-RapidAPI-Key", "4ddd0d73e2msh2deded302b847a8p137d79jsn5d2779dcb9f5" },
        { "X-RapidAPI-Host", "twitter241.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                TwitterFollowersDto twitterFollowersDto =JsonConvert.DeserializeObject<TwitterFollowersDto>(body);
                
                ViewBag.v1 = twitterFollowersDto.data.user.result.legacy.friends_count;
                ViewBag.v2 = twitterFollowersDto.data.user.result.legacy.followers_count;
                
            }
            return View();
        }
    }
}
