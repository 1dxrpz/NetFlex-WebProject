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
            return User.Identity.IsAuthenticated ? View() : RedirectToAction("Index", "Home");
        }

		public async Task<IActionResult> ViewFilm(Guid id)
        {
            try
            {
                FilmDTO filmDTO = await _videoService.GetFilm(id);

                return View(filmDTO);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpGet("Seraes")]
        public async Task<IActionResult> GetSerial(Guid sereasId)
        {
            var getSetial = await _videoService.GetSerial(sereasId);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SerialDTO, SerialViewModel>());
            var mapper = new Mapper(config);
            var sereas = mapper.Map<SerialDTO, SerialViewModel>(getSetial);
            return View(sereas);
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
