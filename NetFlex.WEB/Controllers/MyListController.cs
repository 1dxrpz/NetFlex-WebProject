using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetFlex.BLL.Infrastructure;
using NetFlex.BLL.Interfaces;
using NetFlex.BLL.ModelsDTO;
using NetFlex.WEB.ViewModels;

namespace NetFlex.WEB.Controllers
{
	public class MyListController : Controller
	{
		private IUserService _userService;

        public MyListController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Delete(Guid userId, Guid contentId)
        {
            try
            {
                var selectFavorite = _userService.GetMyList(userId).FirstOrDefault(x => x.ContentId == contentId);
                if (selectFavorite != null)
                {
                    _userService.DeleteFromMyList(selectFavorite.Id);
                }

            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return StatusCode(200);
        }
	}
}
