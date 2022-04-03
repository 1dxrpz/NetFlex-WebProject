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

        public IEnumerable<UserDTO> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<ApplicationUser>, List<UserDTO>>(Database.Users.GetAll());
        }

        public async Task<IEnumerable<string>> GetRoles(string userName)
        {

            return await Database.Users.GetRoles(userName);
        }

        public void AddToMyList(UserFavoriteDTO favorite)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserFavoriteDTO, UserFavorite>()).CreateMapper();
            var add = mapper.Map<UserFavoriteDTO, UserFavorite>(favorite);
            Database.UserFavorites.Create(add);
        }
        public void DeleteFromMyList(Guid favorite)
        {
            Database.UserFavorites.Delete(favorite);
        }

        public IEnumerable<UserFavoriteDTO> GetMyList(Guid userId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserFavorite, UserFavoriteDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<UserFavorite>, List<UserFavoriteDTO>>(Database.UserFavorites.GetAll().Where(f => f.UserId == userId));

        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
