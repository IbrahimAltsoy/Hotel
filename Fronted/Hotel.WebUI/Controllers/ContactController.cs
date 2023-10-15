using Hotel.BusinessLayer.Abstract;
using Hotel.WebUI.Dtos.CategoryMessage;
using Hotel.WebUI.Dtos.ContactDto;
using Hotel.WebUI.Dtos.RoomDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NToastNotify;
using System.Net.Http.Json;
using static Hotel.WebUI.ToastrMessage.ToastrMessage;

namespace Hotel.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _apiAdres = "https://localhost:7064/api/Contact";
        private readonly IToastNotification _toastNotification;
       

        public ContactController(IToastNotification toastNotification, HttpClient httpClient, IHttpClientFactory clientFactory)
        {
            _toastNotification = toastNotification;
            _httpClient = httpClient;
            _clientFactory = clientFactory;
        
        }
        public async Task<IActionResult> Index()
        {
           var model = await _httpClient.GetFromJsonAsync<List<ResultCategoryMessage>>("https://localhost:7064/api/CategoryMessage");
            List<SelectListItem> list = (from item in model
                                         select new SelectListItem
                                         {
                                             Text = item.Name,
                                             Value = item.Id.ToString()
                                         }).ToList(); 
            ViewBag.ListCategoryMessage = list;

            return View();
        }
        [HttpGet]
        public PartialViewResult AddContact()
        {           

            return PartialView();
        }
        [HttpPost]
        public async Task<ActionResult> AddContact(CreateContactDto createContactDto)
        {
          
            if (ModelState.IsValid)
            {
                try
                {

                    var response = await _httpClient.PostAsJsonAsync(_apiAdres, createContactDto);
                    if (response.IsSuccessStatusCode)
                    {
                        _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrAddSuccesfull(createContactDto.Name),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                        return RedirectToAction(nameof(Index),"Default");
                    }

                }
                catch
                {
                    _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrAddUnSuccessfull(createContactDto.Name),
                        new ToastrOptions
                        {
                            Title = "Başarısız"
                        });
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(createContactDto);
        }
        public async Task<ActionResult> UpdateContact(Guid id)
        {
            var model = await _httpClient.GetFromJsonAsync<UpdateContactDto>(_apiAdres + "/" + id);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateContact(Guid id, UpdateContactDto updateContactDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _httpClient.PutAsJsonAsync(_apiAdres + "/" + id, updateContactDto);
                    if (response.IsSuccessStatusCode)
                    {
                        _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrUpdateSuccesfull(updateContactDto.Name),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                        return RedirectToAction(nameof(Index));
                    }

                }
                catch
                {
                    _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrUpdateUnSuccessfull(updateContactDto.Name),
                        new ToastrOptions
                        {
                            Title = "Başarısız"
                        });
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(updateContactDto);
        }
       
    }
}
