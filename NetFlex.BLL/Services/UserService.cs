using AutoMapper;
using NetFlex.BLL.Infrastructure;
using NetFlex.BLL.Interfaces;
using NetFlex.BLL.ModelsDTO;
using NetFlex.DAL.EF;
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

        public UserDTO GetUser(Guid id)
        {

            if (id == null)
                throw new ValidationException("Пользователь с таким id не найден", "");
            var user = Database.Users.Get(id);
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

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
