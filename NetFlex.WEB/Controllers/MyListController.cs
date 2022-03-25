using Microsoft.AspNetCore.Mvc;

namespace NetFlex.WEB.Controllers
{
	public class MyListController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
