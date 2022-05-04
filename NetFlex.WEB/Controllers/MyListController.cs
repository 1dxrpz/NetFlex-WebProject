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
            return User.Identity.IsAuthenticated ? View() : RedirectToAction("Index", "Home");
        }

		[HttpPost]
		public async Task<IActionResult> Delete(Guid userId, Guid contentId)
        {
            try
            {
                var myList = await _userService.GetMyList(userId);
                var selectFavorite = myList.FirstOrDefault(x => x.ContentId == contentId);
                if (selectFavorite != null)
                {
                    await _userService.DeleteFromMyList(selectFavorite.Id);
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
