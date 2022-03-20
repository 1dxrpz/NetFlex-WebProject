using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetFlex.BLL.Infrastructure;
using NetFlex.BLL.Interfaces;
using NetFlex.BLL.ModelsDTO;
using NetFlex.WEB.ViewModels;

namespace NetFlex.WEB.Controllers
{
	public class AdminController : Controller
	{
		private readonly IVideoService _videoService;
		public readonly IRatingService _ratingService;
		public readonly IUserService _userService;

        public AdminController(IVideoService videoService, IRatingService ratingService, IUserService userService)
        {
            _videoService = videoService;
            _ratingService = ratingService;
			_userService = userService;
        }

        public IActionResult Index()
		{
			return View();
		}


		public IActionResult Users()
		{
            var users = _userService.GetUsers().Select(u => new AdminUserVievModel
            {
                UserId = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                LockoutEnabled = u.LockoutEnable,
                Avatar = u.Avatar,
            });

            return View(users);
		}

		[HttpGet("Serials")]
		public IActionResult Serials()
		{
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SerialDTO, SerialViewModel>());
            var mapper = new Mapper(config);
            var serials = mapper.Map<IEnumerable<SerialDTO>, IEnumerable<SerialViewModel>>(_videoService.GetSerials());
			return View(serials);
		}

		[HttpGet("Films")]
		public IActionResult Films()
		{
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FilmDTO, FilmViewModel>());
            var mapper = new Mapper(config);
            var films = mapper.Map<IEnumerable<FilmDTO>, IEnumerable<FilmViewModel>>(_videoService.GetFilms());
			return View(films);
		}

        [HttpPost("UploadFilm")]
        public IActionResult UploadFilm(FilmViewModel model)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<FilmViewModel, FilmDTO>());
                var mapper = new Mapper(config);
                var filmDTO = mapper.Map<FilmViewModel, FilmDTO>(model);
                _videoService.UploadFilm(filmDTO);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(model);
        }

        [HttpPost("UploadSerial")]
        public IActionResult UploadSerial(SerialViewModel model)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<SerialViewModel, SerialDTO>());
                var mapper = new Mapper(config);
                var serialDTO = mapper.Map<SerialViewModel, SerialDTO>(model);
                _videoService.UploadSerial(serialDTO);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(model);
        }

        [HttpPost("UploadEpisode")]
        public IActionResult UploadEpisode(EpisodeViewModel model)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<EpisodeViewModel, EpisodeDTO>());
                var mapper = new Mapper(config);
                var episodeDTO = mapper.Map<EpisodeViewModel, EpisodeDTO>(model);
                _videoService.UploadEpisode(episodeDTO);

            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(model);
        }
    }
}
