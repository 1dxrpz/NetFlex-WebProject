using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;
using NetFlex.BLL.Interfaces;
using NetFlex.BLL.ModelsDTO;
using NetFlex.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.BLL.Services
{
    public class RoleService : IRoleService
    {

        IUnitOfWork Database { get; set; }

        public RoleService(IUnitOfWork database)
        {
            Database = database;
        }

        public RoleDTO Get(string role)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<IdentityRole, RoleDTO>()).CreateMapper();
            return mapper.Map<IdentityRole, RoleDTO>(Database.Roles.Get(role));
        }

        public IQueryable<RoleDTO> GetRoles()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<IdentityRole, RoleDTO>()).CreateMapper();
            return mapper.Map<IQueryable<IdentityRole>, IQueryable<RoleDTO>>(Database.Roles.GetAll());
        }

        public void Create(RoleDTO role)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RoleDTO, IdentityRole>());
            var mapper = new Mapper(config);
            var res = mapper.Map<RoleDTO, IdentityRole>(role);

            Database.Roles.Create(res);
            Database.Save();
        }

        public void Delete(string role)
        {
            var res = Database.Roles.Get(role);

            Database.Roles.Delete(res);
            Database.Save();
        }
        
        public void GiveRole(string role, string user)
        {
            Database.Roles.GiveRole(role, user);
        }

        public void TakeAwayRole(string role, string user)
        {
            Database.Roles.TakeAwayRole(role, user);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
