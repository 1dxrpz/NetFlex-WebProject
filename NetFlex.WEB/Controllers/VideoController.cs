using Microsoft.AspNetCore.Mvc;

namespace NetFlex.WEB.Controllers
{
	public class VideoController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
