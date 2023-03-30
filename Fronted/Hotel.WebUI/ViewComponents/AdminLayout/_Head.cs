using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.AdminLayout
{
	public class _Head:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
