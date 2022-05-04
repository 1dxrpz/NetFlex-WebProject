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
using PagedList;

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
            // ïîëó÷àåì ïîëüçîâàòåëÿ

            var user = await _userService.GetUser(userId);
            if (user != null)
            {
                // ïîëó÷åì ñïèñîê ðîëåé ïîëüçîâàòåëÿ

                var userRoles = await _userService.GetRoles(user.UserName);

                var allRolesDto = await _roleService.GetRoles();

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

        public async Task<IActionResult> Users(int? page, string searchString)
		{
            var getUsers = await _userService.GetUsers();

			for (int i = 0; i < 10; i++)
			{
                getUsers = getUsers.Concat(getUsers);
			}

            var users = getUsers.Select(u => new AdminUserVievModel
            {
                UserId = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                LockoutEnabled = u.LockoutEnable,
                Avatar = u.Avatar
            }).AsQueryable();

            int usersCount = getUsers.Count();

            if (searchString != null)
            {
                users = users.Where(v => v.Email.Contains(searchString) || v.UserId.Contains(searchString));
                usersCount = users.ToList().Count();
            }
            ViewBag.searchString = searchString;
            users = users.ToPagedList(page != null ? (int)page : 1, 32).AsQueryable();
            
            UsersPageViewModel model = new UsersPageViewModel()
            {
                UsersCount = usersCount,
                Users = users.AsEnumerable()
            };
            return View(model);
        }

		public async Task<IActionResult> Serials()
		{
            try
            {
                var getSerials = await _videoService.GetSerials();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<SerialDTO, SerialViewModel>());
                var mapper = new Mapper(config);
                var serials = mapper.Map<IEnumerable<SerialDTO>, IEnumerable<SerialViewModel>>(getSerials);

                var getGenres = await _videoService.GetGenres();
                var config2 = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, GenreViewModel>());
                var mapper2 = new Mapper(config);
                var genres = mapper.Map<IEnumerable<GenreDTO>, IEnumerable<GenreViewModel>>(getGenres);


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

		public async Task<IActionResult> Films()
		{
            try
            {
                var getFilms = await _videoService.GetFilms();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<FilmDTO, FilmViewModel>());
                var mapper = new Mapper(config);
                var films = mapper.Map<IEnumerable<FilmDTO>, IEnumerable<FilmViewModel>>(getFilms);

                films.OrderBy(v => v.Title);

                return View(films);
            }
            catch
            {

            }
            return View();
		}

        public async Task<IActionResult> Genres() 
        {
            var getGenres = await _videoService.GetGenres();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, GenreViewModel>());
            var mapper = new Mapper(config);
            var genres = mapper.Map<IEnumerable<GenreDTO>, List<GenreViewModel>>(getGenres);

            return View(genres);
        }
        public async Task<List<GenreViewModel>> GetGenres()
        {
            var getGenres = await _videoService.GetGenres();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, GenreViewModel>());
            var mapper = new Mapper(config);
            var genres = mapper.Map<IEnumerable<GenreDTO>, List<GenreViewModel>>(getGenres);

            return genres;
        }

        public async Task<IActionResult> Roles()
        {
            var getRoles = await _roleService.GetRoles();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RoleDTO, RoleViewModel>());
            var mapper = new Mapper(config);
            var roles = mapper.Map<IEnumerable<RoleDTO>, List<RoleViewModel>>(getRoles);

            return View(roles);
        }

		#region Lagacy

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
            var user = await _userService.GetUser(userId);

            if (user != null)
            {
                var userRoles = await _userService.GetRoles(user.UserName);
                var addedRoles = roles.Except(userRoles);
                var removedRoles = userRoles.Except(roles);

                await _roleService.GiveRoles(addedRoles.ToList(), user.UserName);

                await _roleService.TakeAwayRoles(removedRoles.ToList(), user.UserName);

                return RedirectToAction("Users");
            }

            return NotFound();
        }

		#endregion

		#region Partials
		#region Add

        public async Task<IActionResult> GetEditUserRolesPartial(string userID)
        {
            var user = await _userService.GetUser(userID);
            if (user != null)
            {
                var userRoles = await _userService.GetRoles(user.UserName);

                var allRolesDto = await _roleService.GetRoles();

                var config = new MapperConfiguration(cfg => cfg.CreateMap<RoleDTO, RoleViewModel>());
                var mapper = new Mapper(config);
                var allRoles = mapper.Map<IEnumerable<RoleDTO>, List<RoleViewModel>>(allRolesDto);


                ChangeRoleViewModel model = new()
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
        
        public IActionResult GetAddRolesPartial()
		{
            return PartialView("Partial/_AddRole");
        }
        public IActionResult GetAddGenrePartial()
        {
            return PartialView("Partial/_AddGenre");
        }
        public IActionResult GetAddMoviePartial()
        {
            return PartialView("Partial/_AddMovie");
        }

		#endregion
		#region Edit
        public async Task<IActionResult> GetEditRolePartial(string id)
        {
            var oldRole = await _roleService.Get(id);
            if (oldRole != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<RoleDTO, RoleViewModel>());
                var mapper = new Mapper(config);
                var newRole = mapper.Map<RoleDTO, RoleViewModel>(oldRole);

                return PartialView("Partial/_EditRole", newRole);
            }

            return NotFound();
        }
        public async Task<IActionResult> GetEditGenrePartial(string id)
        {
            var genres = await _videoService.GetGenres();
            var oldGenre = genres
                .FirstOrDefault(v => v.Id == Guid.Parse(id));
            if (oldGenre != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, GenreViewModel>());
                var mapper = new Mapper(config);
                var newGenre = mapper.Map<GenreDTO, GenreViewModel>(oldGenre);

                return PartialView("Partial/_EditGenre", newGenre);
            }

            return NotFound();
        }
        public async Task<IActionResult> GetEditMoviePartial(string id)
        {
            var movies = await _videoService.GetFilms();
            var movie = movies.FirstOrDefault(v => v.Id == Guid.Parse(id));
            if (movie != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<FilmDTO, FilmViewModel>());
                var mapper = new Mapper(config);
                var tempMovie = mapper.Map<FilmDTO, FilmViewModel>(movie);
                
                var genres = await _videoService.GetGenres(Guid.Parse(id));

                genres.ToList().ForEach(v => tempMovie.FilmGenres.Add(v.GenreName));

                return PartialView("Partial/_EditMovie", tempMovie);
            }

            return NotFound();
        }
        #endregion
        #endregion

        #region Roles
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
            var roles = await _roleService.GetRoles();
            var createdRole = roles.FirstOrDefault(g => g.Name == role);

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
            var roles = await _roleService.GetRoles();
            var role = roles.FirstOrDefault(g => g.Id == id);
            role.Name = newName;
            await _roleService.Update(role);
            return await GetRole(id);
        }
        public async Task<RoleViewModel> GetRole(string id)
		{
            var role = await _roleService.Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RoleDTO, RoleViewModel>());
            var mapper = new Mapper(config);
            var newRole = mapper.Map<RoleDTO, RoleViewModel>(role);
            return newRole;
        }
		#endregion

		#region Genres
		[HttpPost]
        public async Task<GenreViewModel> CreateGenre(string genre)
        {
            var genres = await _videoService.GetGenres();
            var temp = genres.FirstOrDefault(g => g.GenreName == genre);
            if (genre != null && temp == null)
            {
                await _videoService.AddGenre(genre);

                var config = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, GenreViewModel>());
                var mapper = new Mapper(config);
                return mapper.Map<GenreDTO, GenreViewModel>(temp);
            }
            return null;
        }
        [HttpPost]
        public async Task<IActionResult> RemoveGenre(string id)
        {

            if (id != null)
            {
                await _videoService.RemoveGenre(Guid.Parse(id));
                return RedirectToAction("Genres");
            }
            return BadRequest();

        }
        [HttpPost]
        public async Task<GenreViewModel> EditGenre(string id, string newName)
        {
            var genres = await _videoService.GetGenres();
            var oldGenre = genres.FirstOrDefault(g => g.Id == Guid.Parse(id));
            oldGenre.GenreName = newName;
            await _videoService.UpdateGenre(oldGenre);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<GenreDTO, GenreViewModel>());
            var mapper = new Mapper(config);
            return mapper.Map<GenreDTO, GenreViewModel>(oldGenre);
        }
        #endregion

        #region Movie
        
        [HttpPost]
        public async Task<FilmViewModel> CreateMovie(FilmViewModel model)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<FilmViewModel, FilmDTO>());
                var mapper = new Mapper(config);
                var filmDTO = mapper.Map<FilmViewModel, FilmDTO>(model);
                filmDTO.Id = Guid.NewGuid();

                await _videoService.UploadFilm(filmDTO);

                for (int i = 0; i < model.FilmGenres.Count; i++)
                {
                    var genresDto = new GenreVideoDTO
                    {
                        Id = Guid.NewGuid(),
                        ContentId = filmDTO.Id,
                        GenreName = model.FilmGenres[i],
                    };
                    await _videoService.SetGenres(genresDto);
                }
                model.Id = filmDTO.Id;
                return model;
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return null;
            }
        }

        [HttpPost]
        public async Task<FilmViewModel> RemoveMovie(string id)
		{
            var film = await _videoService.GetFilm(Guid.Parse(id));
            await _videoService.RemoveFilm(Guid.Parse(id));
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FilmDTO, FilmViewModel>());
            var mapper = new Mapper(config);
            return mapper.Map<FilmDTO, FilmViewModel>(film);
        }

        [HttpPost]
        public async Task<FilmViewModel> EditMovie(FilmViewModel model, List<string> genres)
        {
            
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FilmViewModel, FilmDTO>());
            var mapper = new Mapper(config);
            var newMovie = mapper.Map<FilmViewModel, FilmDTO>(model);

            var videoGenres = await _videoService.GetGenres(model.Id);


            var addedGenres = genres.Except(videoGenres.Select(g => g.GenreName));

            var removedGenres = videoGenres.Select(g => g.GenreName).Except(genres);

            foreach (var item in genres)
            {
                var genresDto = new GenreVideoDTO
                {
                    Id = Guid.NewGuid(),
                    ContentId = model.Id,
                    GenreName = item,
                };
                await _videoService.SetGenres(genresDto);
            }

            await _videoService.TakeAwayGenres(model.Id.ToString(), removedGenres.ToList());

            await _videoService.UpdateFilm(newMovie);
            
            return model;
        }

        #endregion

    }
}