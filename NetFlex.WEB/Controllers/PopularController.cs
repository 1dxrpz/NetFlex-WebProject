using Microsoft.AspNetCore.Mvc;

namespace NetFlex.WEB.Controllers
{
	public class PopularController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
