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

        public IActionResult Index() => View();

        public IActionResult SubsriptionPlans() => View();

        public IActionResult Episodes() => View();

        public IActionResult CreateRole() => View();

        public async Task<IActionResult> EditUserRole(string userId)
        {
            // получаем пользователя

            var user = await _userService.GetUser(userId);
            if (user != null)
            {
                // получем список ролей пользователя

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


                var serialsView = new FullVideoInfoViewModel
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

		public IActionResult Films()
		{
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<FilmDTO, FilmViewModel>());
                var mapper = new Mapper(config);
                var films = mapper.Map<IEnumerable<FilmDTO>, IEnumerable<FilmViewModel>>(_videoService.GetFilms());

                var config2 = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, GenreViewModel>());
                var mapper2 = new Mapper(config2);
                var genres = mapper2.Map<IEnumerable<GenreDTO>, IEnumerable<GenreViewModel>>(_videoService.GetGenres());


                var filmsView = new FullVideoInfoViewModel
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

        public IActionResult Genres() 
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, GenreViewModel>());
            var mapper = new Mapper(config);
            var genres = mapper.Map<IEnumerable<GenreDTO>, List<GenreViewModel>>(_videoService.GetGenres());

            return View(genres);
        }
        public List<GenreViewModel> GetGenres()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, GenreViewModel>());
            var mapper = new Mapper(config);
            var genres = mapper.Map<IEnumerable<GenreDTO>, List<GenreViewModel>>(_videoService.GetGenres());

            return genres;
        }

        public IActionResult Roles()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RoleDTO, RoleViewModel>());
            var mapper = new Mapper(config);
            var roles = mapper.Map<IEnumerable<RoleDTO>, List<RoleViewModel>>(_roleService.GetRoles());

            return View(roles);
        }

        [HttpPost]
        public void UploadFilm(FilmViewModel model)
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
        }

        [HttpPost]
        public void RemoveMovie(string id)
        {
            /////////// remove movie
        }

        [HttpPost]
        public IActionResult UploadSerial(SerialViewModel model)
        {
            try
            {
                var configS = new MapperConfiguration(cfg => cfg.CreateMap<SerialViewModel, SerialDTO>());
                var mapperS = new Mapper(configS);
                var serialDTO = mapperS.Map<SerialViewModel, SerialDTO>(model);

                var configE = new MapperConfiguration(cfg => cfg.CreateMap<EpisodeViewModel, EpisodeDTO>());
                var mapperE = new Mapper(configE);
                var episdoesDTO = mapperE.Map<List<EpisodeViewModel>, List<EpisodeDTO>>(model.Episodes);

                _videoService.UploadSerial(serialDTO);
                

                foreach(var item in episdoesDTO)
                {
                    item.SerialId = model.Id;
                    _videoService.UploadEpisode(item);
                }

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
        public async Task<IActionResult> ChangeUserRoles(string userId, List<string> roles)
        {
            // получаем пользователя
            var user = await _userService.GetUser(userId);

            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userService.GetRoles(user.UserName);
                // получаем все роли
                var allRolesDto = _roleService.GetRoles();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(roles);

                await _roleService.GiveRoles(addedRoles.ToList(), user.UserName);

                await _roleService.TakeAwayRoles(removedRoles.ToList(), user.UserName);

                return RedirectToAction("Users");
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult AddGenre(string genre)
        {

            if (genre != null && _videoService.GetGenres().FirstOrDefault(g => g.GenreName == genre) == null)
            {
                _videoService.AddGenre(genre);
                return RedirectToAction("Genres");
            }
            return StatusCode(400);
        }

        [HttpPost]
        public IActionResult EditGenre(string id, string newName)
        {
            var oldGenre = _videoService.GetGenres().FirstOrDefault(g => g.Id == Guid.Parse(id));
            if (oldGenre != null)
            {
                oldGenre.GenreName = newName;
                _videoService.UpdateGenre(oldGenre);
                return RedirectToAction("Genres");
            }
            return StatusCode(400);
        }

        [HttpPost]
        public IActionResult RemoveGenre(string id)
        {

            if (id != null)
            {
                _videoService.RemoveGenre(Guid.Parse(id));
                return RedirectToAction("Genres");
            }
            return BadRequest();
        }
        [HttpGet]
        public GenreViewModel GetGenre(string id)
		{
            var model = _videoService.GetGenres().FirstOrDefault(v => v.Id == Guid.Parse(id));

            var config = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, GenreViewModel>());
            var mapper = new Mapper(config);
            return mapper.Map<GenreDTO, GenreViewModel>(model);

        }

        /// Всю эту залупонь сверху /\ удалить нахуй и сделать api

        /// Все в partials

        [HttpGet]
        public async Task<IActionResult> GetEditUserRolesPartial(string userID)
        {
            var user = await _userService.GetUser(userID);
            if (user != null)
            {
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
                return PartialView("Partial/_EditUserRoles", model);
            }

            return NotFound();
        }
        [HttpGet]
        public IActionResult GetAddRolesPartial()
		{
            return PartialView("Partial/_AddRole");
        }
        [HttpGet]
        public IActionResult GetEditRolePartial(string id)
        {
            var oldRole = _roleService.Get(id);
            if (oldRole != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<RoleDTO, RoleViewModel>());
                var mapper = new Mapper(config);
                var newRole = mapper.Map<RoleDTO, RoleViewModel>(oldRole);

                return PartialView("Partial/_EditRole", newRole);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<RoleViewModel> CreateRole(string role)
        {
            try
            {
                await _roleService.Create(role);
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return null;
            }
            
            var createdRole = _roleService.GetRoles().FirstOrDefault(g => g.Name == role);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<RoleDTO, RoleViewModel>());
            var mapper = new Mapper(config);
            var newRole = mapper.Map<RoleDTO, RoleViewModel>(createdRole);
            return newRole;
        }
        [HttpPost]
        public async Task<IActionResult> RemoveRole(string id)
        {
            if (id != null)
            {
                await _roleService.Delete(id);
                return RedirectToAction("Roles");
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<RoleViewModel> EditRole(string id, string newName)
        {
            var role = _roleService.GetRoles().FirstOrDefault(g => g.Id == id);
            role.Name = newName;
            await _roleService.Update(role);
            return GetRole(id);
        }
        public RoleViewModel GetRole(string id)
		{
            var role = _roleService.Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RoleDTO, RoleViewModel>());
            var mapper = new Mapper(config);
            var newRole = mapper.Map<RoleDTO, RoleViewModel>(role);
            return newRole;
        }
    }
}
