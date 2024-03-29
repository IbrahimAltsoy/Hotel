﻿using Hotel.WebUI.Dtos.RoomDto;
using Hotel.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hotel.WebUI.ViewComponents.UI
{
    public class _UIServiceStart:ViewComponent
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _apiAdres = "https://localhost:7064/api/Service";


        public _UIServiceStart(HttpClient httpClient, IHttpClientFactory clientFactory)
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
                var model = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(model.Take(6).ToList());
            }
            return View();
        }
    }
}
