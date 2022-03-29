using AutoMapper;
using Microsoft.AspNetCore.Identity;
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

        public IEnumerable<RoleDTO> GetRoles()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<IdentityRole, RoleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<IdentityRole>, List<RoleDTO>>(Database.Roles.GetAll());
        }

        public async Task Create(RoleDTO role)
        {
            var identityRole = new IdentityRole(role.Name); 

            await Database.Roles.Create(identityRole);
            Database.Save();
        }

        public async Task Delete(string role)
        {
            var res = Database.Roles.Get(role);

            await Database.Roles.Delete(res);
            Database.Save();
        }
        
        public async Task GiveRole(string role, string user)
        {
            await Database.Roles.GiveRole(role, user);
        }

        public async Task TakeAwayRole(string role, string user)
        {
            await Database.Roles.TakeAwayRole(role, user);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
