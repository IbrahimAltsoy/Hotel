using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.AdminLayout
{
    public class _Footer:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
