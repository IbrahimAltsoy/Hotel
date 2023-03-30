using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.AdminLayout
{
	public class _Sidebar:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
