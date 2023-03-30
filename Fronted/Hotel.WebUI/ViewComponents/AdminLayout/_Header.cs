using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.AdminLayout
{
	public class _Header:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
