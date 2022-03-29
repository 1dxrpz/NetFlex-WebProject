using AutoMapper;
using NetFlex.DAL.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetFlex.BLL.Infrastructure;
using NetFlex.BLL.Interfaces;
using NetFlex.BLL.ModelsDTO;
using NetFlex.DAL.Enums;
using NetFlex.WEB.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace NetFlex.WEB.Controllers
{
    //[Authorize(Policy = Constants.Policies.RequireAdmin)]
    public class AdminController : Controller
	{
        RoleManager<IdentityRole> _roleManager;

        private readonly IVideoService _videoService;
		public readonly IRatingService _ratingService;
		public readonly IUserService _userService;
        public readonly IRoleService _roleService;
        public AdminController(RoleManager<IdentityRole> rm,IVideoService videoService, IRatingService ratingService, IUserService userService, IRoleService roleService)
        {
            _videoService = videoService;
            _ratingService = ratingService;
			_userService = userService;
            _roleService = roleService;
            _roleManager = rm;
        }

        public IActionResult Index()
		{
            return View();
		}

        public IActionResult SubsriptionPlans()
        {
            return View();
        }
        public IActionResult Episodes()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Users()
		{
            var users = _userService.GetUsers().Select(u => new AdminUserVievModel
            {
                UserId = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                LockoutEnabled = u.LockoutEnable,
                Avatar = u.Avatar
            });

            return View(users);
		}

		[HttpGet]
		public IActionResult Serials()
		{
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SerialDTO, SerialViewModel>());
            var mapper = new Mapper(config);
            var serials = mapper.Map<IEnumerable<SerialDTO>, IEnumerable<SerialViewModel>>(_videoService.GetSerials());

			return View(serials);
		}

		[HttpGet]
		public IActionResult Films()
		{
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FilmDTO, FilmViewModel>());
            var mapper = new Mapper(config);
            var films = mapper.Map<IEnumerable<FilmDTO>, IEnumerable<FilmViewModel>>(_videoService.GetFilms());

			return View(films);
		}

		[HttpGet]
        public IActionResult Roles() 
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RoleDTO, RoleViewModel>());
            var mapper = new Mapper(config);
            var roles = mapper.Map<IEnumerable<RoleDTO>, List<RoleViewModel>>(_roleService.GetRoles());

            return View(roles);
        }

        [HttpPost]
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
            return RedirectToAction("Films");
        }

        [HttpPost]
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
            return RedirectToAction("Serials");
        }

        [HttpPost]
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
            return StatusCode(200);

        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string name)
        {
            try
            {
                var roleDto = new RoleDTO()
                {
                    Name = name,
                };

                await _roleService.Create(roleDto);

            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return RedirectToAction("Roles");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string role)
        {
            try
            {
                await _roleService.Delete(role);

            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return RedirectToAction("Roles");
        }

        [HttpPost]
        public async Task<IActionResult> GiveRole(string user, string role)
        {
            try
            {
                await _roleService.GiveRole(role, user);

            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return StatusCode(200);
        }

        [HttpPost]
        public IActionResult TakeAwayRole([FromBody] string user, string role)
        {
            try
            {
                _roleService.TakeAwayRole(role, user);

            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            return StatusCode(200);
        }
    }
}
