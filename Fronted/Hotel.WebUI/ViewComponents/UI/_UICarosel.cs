using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.UI
{
    public class _UICarosel:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
