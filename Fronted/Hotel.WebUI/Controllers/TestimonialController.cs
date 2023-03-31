using Hotel.WebUI.Models.Stuff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;
using static Hotel.WebUI.ToastrMessage.ToastrMessage;
using System.Text;
using Hotel.WebUI.Models.Testimonial;

namespace Hotel.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres = "https://localhost:7064/api/Testimonial";
        private readonly IToastNotification _toastNotification;

        public TestimonialController(IHttpClientFactory clientFactory, HttpClient httpClient, IToastNotification toastNotification)
        {
            _clientFactory = clientFactory;
            _httpClient = httpClient;
            _toastNotification = toastNotification;

        }
        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(_apiAdres);
            if (response.IsSuccessStatusCode)
            {

                var jsonData = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<List<AddTestimonialViewModel>>(jsonData);
                return View(model);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTestimonial(AddTestimonialViewModel testimonial)
        {
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(testimonial);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_apiAdres, stringContent);
            if (response.IsSuccessStatusCode)
            {
                _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrAddSuccesfull(testimonial.Name),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _toastNotification.AddErrorToastMessage(MessajeToastr.ToastrAddUnSuccessfull(testimonial.Name),
                        new ToastrOptions
                        {
                            Title = "Başarısız!!!"
                        });
                return View();
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTEstimonial(Guid id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7064/api/Stuff/{id}");
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction(nameof(Index));

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(Guid id)
        {
            var model = await _httpClient.GetFromJsonAsync<UpdateTestimonialViewModel>(_apiAdres + "/" + id);
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(Guid id, UpdateTestimonialViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cevap = await _httpClient.PutAsJsonAsync(_apiAdres + "/" + id, model);
                    if (cevap.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(model);
        }
    }
}
