using Microsoft.AspNetCore.Mvc;
using NetFlex.WEB.ViewModels;

namespace NetFlex.WEB.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Users()
		{
			List<AdminUserVievModel> users = new List<AdminUserVievModel>();
            for (int i = 0; i < 10; i++)
            {
				users.Add(new AdminUserVievModel()
				{
					Avatar = "none",
					Email = "s@mail.ru",
					LockoutEnabled = true,
					Password = "123123",
					PhoneNumber = "89873441488",
					UserName = "soska",
					UserId = Guid.NewGuid()
				});
			}
			return View(users);
		}
	}
}
