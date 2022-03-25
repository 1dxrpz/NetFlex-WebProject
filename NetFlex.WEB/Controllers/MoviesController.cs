using Microsoft.AspNetCore.Mvc;

namespace NetFlex.WEB.Controllers
{
	public class MoviesController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
