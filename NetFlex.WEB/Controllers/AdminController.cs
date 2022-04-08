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

        [HttpGet]
        public IActionResult Index() => View();

        [HttpGet]
        public IActionResult SubsriptionPlans() => View();

        [HttpGet]
        public IActionResult Episodes() => View();

        [HttpGet]
        public IActionResult Create() => View();

        [HttpGet]
        public async Task<IActionResult> Edit(string userId)
        {
            // �������� ������������

            var user = await _userService.GetUser(userId);
            if (user != null)
            {
                // ������� ������ ����� ������������

                var userRoles = await _userService.GetRoles(user.UserName);

                var allRolesDto = _roleService.GetRoles();

                var config = new MapperConfiguration(cfg => cfg.CreateMap<RoleDTO, RoleViewModel>());
                var mapper = new Mapper(config);
                var allRoles = mapper.Map<IEnumerable<RoleDTO>, List<RoleViewModel>>(allRolesDto);


                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles.ToList(),
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
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
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<SerialDTO, SerialViewModel>());
                var mapper = new Mapper(config);
                var serials = mapper.Map<IEnumerable<SerialDTO>, IEnumerable<SerialViewModel>>(_videoService.GetSerials());

                var config2 = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, GenreViewModel>());
                var mapper2 = new Mapper(config);
                var genres = mapper.Map<IEnumerable<GenreDTO>, IEnumerable<GenreViewModel>>(_videoService.GetGenres());


                var serialsView = new FullInfoViewModel
                {
                    Serials = serials.ToList(),
                    Genres = genres.ToList(),
                };

                return View(serialsView);
            }
            catch
            {

            }
            return View();
        }

		[HttpGet]
		public IActionResult Films()
		{
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<FilmDTO, FilmViewModel>());
                var mapper = new Mapper(config);
                var films = mapper.Map<IEnumerable<FilmDTO>, IEnumerable<FilmViewModel>>(_videoService.GetFilms());

                var config2 = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, GenreViewModel>());
                var mapper2 = new Mapper(config);
                var genres = mapper.Map<IEnumerable<GenreDTO>, IEnumerable<GenreViewModel>>(_videoService.GetGenres());


                var filmsView = new FullInfoViewModel
                {
                    Films = films.ToList(),
                    Genres = genres.ToList(),
                };

                return View(filmsView);
            }
            catch
            {

            }
            return View();
		}

		[HttpGet]
        public IActionResult Genres() 
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, GenreViewModel>());
            var mapper = new Mapper(config);
            var genres = mapper.Map<IEnumerable<GenreDTO>, List<GenreViewModel>>(_videoService.GetGenres());

            return View(genres);
        }

        [HttpGet]
        public IActionResult Roles()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RoleDTO, RoleViewModel>());
            var mapper = new Mapper(config);
            var roles = mapper.Map<IEnumerable<RoleDTO>, List<RoleViewModel>>(_roleService.GetRoles());

            return View(roles);
        }

        [HttpGet]
        public IActionResult UploadFilm()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, GenreViewModel>());
            var mapper = new Mapper(config);
            var genres = mapper.Map<IEnumerable<GenreDTO>, List<GenreViewModel>>(_videoService.GetGenres());

            return View(new FilmViewModel
            {
                AllGenres = genres,
            });
        }

        [HttpPost]
        public IActionResult UploadFilm(FilmViewModel model)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<FilmViewModel, FilmDTO>());
                var mapper = new Mapper(config);
                var filmDTO = mapper.Map<FilmViewModel, FilmDTO>(model);
                filmDTO.Id = Guid.NewGuid();

                _videoService.UploadFilm(filmDTO);

                for (int i = 0; i < model.FilmGenres.Count; i++)
                {
                    var genresDto = new GenreVideoDTO
                    {
                        Id = Guid.NewGuid(),
                        ContentId = filmDTO.Id,
                        GenreName = model.FilmGenres[i],
                    };
                    _videoService.SetGenres(genresDto);
                }
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

                foreach (var item in model.Genres)
                {
                    var genresDto = new GenreVideoDTO
                    {
                        Id = Guid.NewGuid(),
                        ContentId = model.Id,
                        GenreName = item.GenreName,
                    };
                    _videoService.SetGenres(genresDto);
                }
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
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            // �������� ������������
            var user = await _userService.GetUser(userId);

            if (user != null)
            {
                // ������� ������ ����� ������������
                var userRoles = await _userService.GetRoles(user.UserName);
                // �������� ��� ����
                var allRolesDto = _roleService.GetRoles();
                // �������� ������ �����, ������� ���� ���������
                var addedRoles = roles.Except(userRoles);
                // �������� ����, ������� ���� �������
                var removedRoles = userRoles.Except(roles);

                await _roleService.GiveRoles(addedRoles.ToList(), user.UserName);

                await _roleService.TakeAwayRoles(removedRoles.ToList(), user.UserName);

                return RedirectToAction("Users");
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string role)
        {
            try
            {
                await _roleService.Create(role);

            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return RedirectToAction("Users");
        }

        [HttpPost]
        public IActionResult AddGenre(string genre)
        {

            if (genre != null && _videoService.GetGenres().FirstOrDefault(g => g.GenreName == genre) == null)
            {
                _videoService.AddGenre(genre);
                return Ok();
            }

            return BadRequest();
        }
    }
}
