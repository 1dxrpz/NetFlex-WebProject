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

        public IActionResult Index()
		{
			return View();
		}

		public IActionResult ViewFilm(Guid id)
        {
            try
            {
                FilmDTO filmDTO = _videoService.GetFilm(id);

                return View(filmDTO);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpGet("Seraes")]
        public IActionResult GetSerial(Guid sereasId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SerialDTO, SerialViewModel>());
            var mapper = new Mapper(config);
            var sereas = mapper.Map<SerialDTO, SerialViewModel>(_videoService.GetSerial(sereasId));
            return View(sereas);
        }

        [HttpGet("Movie")]
        public IActionResult GetFilm(Guid movieId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FilmDTO, FilmViewModel>());
            var mapper = new Mapper(config);
            var movie = mapper.Map<FilmDTO, FilmViewModel>(_videoService.GetFilm(movieId));
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
                _ratingService.SetRating(reviewDTO);

            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return StatusCode(200);
        }

        [HttpPost]
        public IActionResult AddToMyList(UserFavoriteViewModel model)
        {
            try
            {
                if(_userService.GetMyList(model.UserId).Where(x => x.ContentId == model.ContentId) == null)
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<UserFavoriteViewModel, UserFavoriteDTO>());
                    var mapper = new Mapper(config);
                    var favoritesDto = mapper.Map<UserFavoriteViewModel, UserFavoriteDTO>(model);

                    _userService.AddToMyList(favoritesDto);
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
