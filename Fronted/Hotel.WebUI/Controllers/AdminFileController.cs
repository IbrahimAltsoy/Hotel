using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Hotel.WebUI.Controllers
{
    public class AdminFileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var bytles = stream.ToArray();
            ByteArrayContent byteArrayContent = new ByteArrayContent(bytles);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent, "file", file.Name);
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.PostAsync("https://localhost:7064/api/FileProcess", multipartFormDataContent);


            return View();
        }
    }
}
