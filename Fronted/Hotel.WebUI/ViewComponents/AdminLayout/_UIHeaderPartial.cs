using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.AdminLayout
{
    public class _UIHeaderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
