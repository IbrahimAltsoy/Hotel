using Microsoft.AspNetCore.Mvc;

namespace Hotel.WebUI.ViewComponents.AdminLayout
{
	public class _Script:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
