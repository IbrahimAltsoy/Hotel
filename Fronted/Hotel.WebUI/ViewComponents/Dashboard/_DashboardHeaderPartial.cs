using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.Dashboard
{
    public class _DashboardHeaderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
