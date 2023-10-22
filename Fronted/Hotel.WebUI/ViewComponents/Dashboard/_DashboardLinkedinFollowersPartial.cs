using Hotel.WebUI.Dtos.DashboardFollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hotel.WebUI.ViewComponents.Dashboard
{
    public class _DashboardLinkedinFollowersPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
    //        var client = new HttpClient();
    //        var request = new HttpRequestMessage
    //        {
    //            Method = HttpMethod.Get,
    //            RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fibrahim-altsoy-050717183%2F"),
    //            Headers =
    //{
    //    { "X-RapidAPI-Key", "4ddd0d73e2msh2deded302b847a8p137d79jsn5d2779dcb9f5" },
    //    { "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    //},
    //        };
    //        using (var response = await client.SendAsync(request))
    //        {
    //            response.EnsureSuccessStatusCode();
    //            var body = await response.Content.ReadAsStringAsync();
    //            LinkedinFollowersCountDto linkedinFollowersCountDto = JsonConvert.DeserializeObject<LinkedinFollowersCountDto>(body);
               
    //            ViewBag.v1 = linkedinFollowersCountDto.data.followers_count;
    //            ViewBag.v2 = linkedinFollowersCountDto.data.connections_count;
                
    //        }
            return View();
        }
    }
}
