using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.UI
{
    public class _UIJavaScript : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
