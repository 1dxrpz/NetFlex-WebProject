using AutoMapper;
using NetFlex.BLL.Infrastructure;
using NetFlex.BLL.Interfaces;
using NetFlex.BLL.ModelsDTO;
using NetFlex.DAL.EF;
using NetFlex.DAL.Entities;
using NetFlex.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork database)
        {
            Database = database;
        }

        public async Task<UserDTO> GetUser(string id)
        {

            if (id == null)
                throw new ValidationException("Пользователь с таким id не найден", "");
            var user = await Database.Users.Get(id);
            if (user == null)
                throw new ValidationException("Пользователь не найден", "");

            return new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                TwoFactorEnable = user.TwoFactorEnabled,
                LockoutEnable = user.TwoFactorEnabled

            };
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var users = await Database.Users.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<ApplicationUser>, List<UserDTO>>(users);
        }

        public async Task<IEnumerable<string>> GetRoles(string userName)
        {

            return await Database.Users.GetRoles(userName);
        }

        public async Task AddToMyList(UserFavoriteDTO favorite)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserFavoriteDTO, UserFavorite>()).CreateMapper();
            var add = mapper.Map<UserFavoriteDTO, UserFavorite>(favorite);
            await Database.UserFavorites.Create(add);
        }
        public async Task DeleteFromMyList(Guid favorite)
        {
            await Database.UserFavorites.Delete(favorite);
        }

        public async Task<IEnumerable<UserFavoriteDTO>> GetMyList(Guid userId)
        {
            var userFavorites = await Database.UserFavorites.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserFavorite, UserFavoriteDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<UserFavorite>, List<UserFavoriteDTO>>(userFavorites.Where(f => f.UserId == userId));

        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
