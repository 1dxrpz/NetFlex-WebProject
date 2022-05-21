using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetFlex.BLL.Interfaces;
using NetFlex.BLL.ModelsDTO;
using NetFlex.WEB.ViewModels;

namespace NetFlex.WEB.Controllers
{
	public class MainController : Controller
	{
		private IVideoService _videoService;

		public MainController(IVideoService videoService)
		{
			_videoService = videoService;
		}

		public async Task<IActionResult> IndexAsync()
		{
			var getFilms = await _videoService.GetFilms();
			var config = new MapperConfiguration(cfg => cfg.CreateMap<FilmDTO, FilmViewModel>());
			var mapper = new Mapper(config);
			var movies = mapper.Map<IEnumerable<FilmDTO>, IEnumerable<FilmViewModel>>(getFilms);

			var getSerials = await _videoService.GetSerials();
			var config1 = new MapperConfiguration(cfg => cfg.CreateMap<SerialDTO, SerialViewModel>());
			var mapper1 = new Mapper(config1);
			var serials = mapper1.Map<IEnumerable<SerialDTO>, IEnumerable<SerialViewModel>>(getSerials);

			var model = new MainPageViewModel()
			{
				Series = serials.ToList(),
				Movies = movies.ToList()
			};

			return User.Identity.IsAuthenticated ? View(model) : RedirectToAction("Index", "Home");
		}
	}
}
