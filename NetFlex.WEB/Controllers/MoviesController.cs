using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetFlex.BLL.Interfaces;
using NetFlex.BLL.ModelsDTO;
using NetFlex.WEB.ViewModels;

namespace NetFlex.WEB.Controllers
{
	public class MoviesController : Controller
	{
        private IVideoService _videoService;

        public MoviesController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        public async Task<IActionResult> Index()
		{
            var getFilms = await _videoService.GetFilms();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FilmDTO, FilmViewModel>());
            var mapper = new Mapper(config);
            var movies = mapper.Map<IEnumerable<FilmDTO>, IEnumerable<FilmViewModel>>(getFilms);

            return View(movies);
		}
	}
}
