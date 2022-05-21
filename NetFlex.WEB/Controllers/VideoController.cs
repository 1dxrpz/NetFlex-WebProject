using Microsoft.AspNetCore.Mvc;
using NetFlex.BLL.Infrastructure;
using NetFlex.BLL.Interfaces;
using NetFlex.BLL.ModelsDTO;
using NetFlex.WEB.ViewModels;
using AutoMapper;

namespace NetFlex.WEB.Controllers
{
	public class VideoController : Controller
	{
		private readonly IVideoService _videoService;
        private readonly IUserService _userService;
        public readonly IRatingService _ratingService;
        public readonly IReviewService _reviewService;

        public VideoController(IVideoService videoService, IReviewService reviewService,IRatingService ratingService, IUserService userService)
        {
            _videoService = videoService;
            _reviewService = reviewService;
            _ratingService = ratingService;
            _userService = userService;
        }

        public IActionResult Index(Guid id)
		{
            return User.Identity.IsAuthenticated ? View() : RedirectToAction("Index", "Home");
        }

		public async Task<IActionResult> Movie(Guid id)
        {
            try
            {
                FilmDTO filmDTO = await _videoService.GetFilm(id);

                var getFilm = await _videoService.GetFilm(id);
                var config = new MapperConfiguration(cfg => cfg.CreateMap<FilmDTO, FilmViewModel>());
                var mapper = new Mapper(config);
                var movie = mapper.Map<FilmDTO, FilmViewModel>(getFilm);

                var getGenres = await _videoService.GetGenres(id);
                var config1 = new MapperConfiguration(cfg => cfg.CreateMap<GenreVideoDTO, GenreVideosViewModel>());
                var mapper1 = new Mapper(config1);
                var genres = mapper1.Map<IEnumerable<GenreVideoDTO>, List<GenreVideosViewModel>>(getGenres);

				var getReviews = await _reviewService.GetReviews(id);
				var config2 = new MapperConfiguration(cfg => cfg.CreateMap<ReviewDTO, ReviewViewModel>());
				var mapper2 = new Mapper(config2);
				var reviews = mapper2.Map<IEnumerable<ReviewDTO>, List<ReviewViewModel>>(getReviews);

				var fullVideo = new FullVideoInfoViewModel()
                {
                    Film = movie,
                    Genres = genres,
                    Reviews = reviews
                };

                return View(fullVideo);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        public async Task<IActionResult> Serial(Guid id)
        {
            try
            {
                var getSerial = await _videoService.GetSerial(id);
                var config = new MapperConfiguration(cfg => cfg.CreateMap<SerialDTO, SerialViewModel>());
                var mapper = new Mapper(config);
                var serial = mapper.Map<SerialDTO, SerialViewModel>(getSerial);

                var getGenres = await _videoService.GetGenres(id);
                var config1 = new MapperConfiguration(cfg => cfg.CreateMap<GenreVideoDTO, GenreVideosViewModel>());
                var mapper1 = new Mapper(config1);
                var genres = mapper1.Map<IEnumerable<GenreVideoDTO>, List<GenreVideosViewModel>>(getGenres);

                var getReviews = await _reviewService.GetReviews(id);
                var config2 = new MapperConfiguration(cfg => cfg.CreateMap<ReviewDTO, ReviewViewModel>());
                var mapper2 = new Mapper(config2);
                var reviews = mapper2.Map<IEnumerable<ReviewDTO>, List<ReviewViewModel>>(getReviews);

                var getEpisodes = await _videoService.GetEpisodes(id);
                var config3 = new MapperConfiguration(cfg => cfg.CreateMap<EpisodeDTO, EpisodeViewModel>());
                var mapper3 = new Mapper(config3);
                var episodes = mapper3.Map<IEnumerable<EpisodeDTO>, List<EpisodeViewModel>> (getEpisodes);

                serial.Episodes = episodes;

                var fullVideo = new FullVideoInfoViewModel()
                {
                    Serial = serial,
                    Genres = genres,
                    Reviews = reviews,
                };

                return View(fullVideo);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpGet("Movie")]
        public async Task<IActionResult> GetFilm(Guid movieId)
        {
            var getFilm = await _videoService.GetFilm(movieId);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FilmDTO, FilmViewModel>());
            var mapper = new Mapper(config);
            var movie = mapper.Map<FilmDTO, FilmViewModel>(getFilm);
            return View(movie);
        }

        [HttpPost("PublicReview")]
        public async Task<IActionResult> PublicReview(ReviewViewModel model)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ReviewViewModel, ReviewDTO>());
                var mapper = new Mapper(config);
                var reviewDTO = mapper.Map<ReviewViewModel, ReviewDTO>(model);
                await _reviewService.PublishReview(reviewDTO);
                await _ratingService.SetRating(reviewDTO);

            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return StatusCode(200);
        }

        [HttpPost]
        public async Task<IActionResult> AddToMyList(UserFavoriteViewModel model)
        {
            try
            {
                var myList = await _userService.GetMyList(model.UserId);
                if (myList.Where(x => x.ContentId == model.ContentId) == null)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<UserFavoriteViewModel, UserFavoriteDTO>());
                    var mapper = new Mapper(config);
                    var favoritesDto = mapper.Map<UserFavoriteViewModel, UserFavoriteDTO>(model);

                    await _userService.AddToMyList(favoritesDto);
                };
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return StatusCode(200);
        }

    }
}
