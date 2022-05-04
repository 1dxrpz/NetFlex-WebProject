﻿using Microsoft.AspNetCore.Mvc;

namespace NetFlex.WEB.Controllers
{
	public class MainController : Controller
	{
		public IActionResult Index()
		{
			return User.Identity.IsAuthenticated ? View() : RedirectToAction("Index", "Home");
		}
	}
}
