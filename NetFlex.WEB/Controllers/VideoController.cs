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
        public readonly IReviewService _reviewService;
        public readonly IRatingService _ratingService;

        public VideoController(IVideoService videoService, IReviewService reviewService,IRatingService ratingService)
        {
            _videoService = videoService;
            _reviewService = reviewService;
            _ratingService = ratingService;
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
