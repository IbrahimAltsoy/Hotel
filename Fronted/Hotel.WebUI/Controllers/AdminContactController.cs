using Hotel.WebUI.Dtos.ContactDto;
using Hotel.WebUI.Dtos.SenderMessageDto;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using static Hotel.WebUI.ToastrMessage.ToastrMessage;

namespace Hotel.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _apiAdres = "https://localhost:7064/api/Contact";
        private readonly IToastNotification _toastNotification;

        public AdminContactController(IToastNotification toastNotification, HttpClient httpClient, IHttpClientFactory clientFactory)
        {
            _toastNotification = toastNotification;
            _httpClient = httpClient;
            _clientFactory = clientFactory;
        }
        public async Task<IActionResult> Inbox()
        {
            var model = await _httpClient.GetFromJsonAsync<List<ResultSenderMessage>>("https://localhost:7064/api/SenderMessage");
            var model1 = await _httpClient.GetFromJsonAsync<List<ResultContactDto>>("https://localhost:7064/api/Contact");
            ViewBag.countSenderMessage = model.Count();
            ViewBag.countContact = model1.Count();

            return View(model);
        }
        //public async Task<IActionResult> SenderMessage()
        //{
        //    var model = await _httpClient.GetFromJsonAsync<List<ResultSenderMessage>>("https://localhost:7064/api/SenderMessage");

        //    return View(model);
        //}
        public async Task<PartialViewResult> SideBarAdminContactPartial()
        {
            var model = await _httpClient.GetFromJsonAsync<List<ResultSenderMessage>>("https://localhost:7064/api/SenderMessage");
            
            return new PartialViewResult();
        }
        public PartialViewResult SideBarCategoryAdminContactPartial()
        {
            return new PartialViewResult();
        }

        public ActionResult AddSenderMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddSenderMessage(CreateSenderMessageDto createSenderMessage)
        {
           
            createSenderMessage.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            if (ModelState.IsValid)
            {
                try
                {

                    var response = await _httpClient.PostAsJsonAsync("https://localhost:7064/api/SenderMessage", createSenderMessage);
                    if (response.IsSuccessStatusCode)
                    {
                        _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrAddSuccesfull(createSenderMessage.Title),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                        Redirect("/AdminContact/Inbox/");
                    }

                }
                catch
                {
                    _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrAddUnSuccessfull(createSenderMessage.Title),
                        new ToastrOptions
                        {
                            Title = "Başarısız"
                        });
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(createSenderMessage);
        }
        public async Task<ActionResult> UpdateSenderMessage(Guid id)
        {
            var model = await _httpClient.GetFromJsonAsync<UpdateSenderMessage>("https://localhost:7064/api/SenderMessage" + "/" + id);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateSenderMessage(Guid id, UpdateSenderMessage updateSenderMessage)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _httpClient.PutAsJsonAsync("https://localhost:7064/api/SenderMessage" + "/" + id, updateSenderMessage);
                    if (response.IsSuccessStatusCode)
                    {
                        _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrUpdateSuccesfull(updateSenderMessage.Title),
                        new ToastrOptions
                        {
                            Title = "Başarılı"
                        });
                        return RedirectToAction(nameof(Index));
                    }

                }
                catch
                {
                    _toastNotification.AddSuccessToastMessage(MessajeToastr.ToastrUpdateUnSuccessfull(updateSenderMessage.Title),
                        new ToastrOptions
                        {
                            Title = "Başarısız"
                        });
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }

            return View(updateSenderMessage);
        }
        [HttpGet]
        public async Task<IActionResult> MessageDetailsSendBox(Guid id)
        {
            var model = await _httpClient.GetFromJsonAsync<UpdateSenderMessage>("https://localhost:7064/api/SenderMessage" + "/" + id);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> MessageDetailsInbox(Guid id)
        {
            var model = await _httpClient.GetFromJsonAsync<ResultContactDto>("https://localhost:7064/api/Contact" + "/" + id);
            return View(model);
        }

    }
}
