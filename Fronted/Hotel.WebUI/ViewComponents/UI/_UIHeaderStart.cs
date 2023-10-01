using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.UI
{
    public class _UIHeaderStart:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
