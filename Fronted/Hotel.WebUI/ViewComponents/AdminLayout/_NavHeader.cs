using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.AdminLayout
{
	public class _NavHeader:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
