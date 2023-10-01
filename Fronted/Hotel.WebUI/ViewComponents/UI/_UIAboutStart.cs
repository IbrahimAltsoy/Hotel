using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.UI
{
    public class _UIAboutStart:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
