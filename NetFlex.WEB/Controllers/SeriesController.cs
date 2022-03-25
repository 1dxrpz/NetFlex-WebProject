using Microsoft.AspNetCore.Mvc;

namespace NetFlex.WEB.Controllers
{
	public class SeriesController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
