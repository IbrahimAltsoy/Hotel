using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.UI
{
    public class _UIServiceStart:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
