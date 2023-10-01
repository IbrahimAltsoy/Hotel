using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.UI
{
    public class _UISpinner:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
