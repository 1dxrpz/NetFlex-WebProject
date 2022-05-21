using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NetFlex.BLL.Infrastructure;
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

        public async Task<RoleDTO> Get(string id)
        {
            var role = await Database.Roles.Get(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<IdentityRole, RoleDTO>()).CreateMapper();
            return mapper.Map<IdentityRole, RoleDTO>(role);
        }

        public async Task<IEnumerable<RoleDTO>> GetRoles()
        {
            var role = await Database.Roles.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<IdentityRole, RoleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<IdentityRole>, List<RoleDTO>>(role);
        }

        public async Task Create(string role)
        {
            var identityRole = new IdentityRole(role);
            var roles = await Database.Roles.GetAll();
            if (roles.FirstOrDefault(r => r.Name == role) != null)
                throw new ValidationException("", "");
            await Database.Roles.Create(identityRole);
            
            Database.Save();
        }

        public async Task Delete(string id)
        {
            var res = await Database.Roles.Get(id);
            
            await Database.Roles.Delete(res);
            Database.Save();
            
        }

        public async Task Update(RoleDTO editedRole)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RoleDTO, IdentityRole>());
            var mapper = new Mapper(config);
            var temp = mapper.Map<RoleDTO, IdentityRole>(editedRole);
            var g = await Database.Roles.Get(editedRole.Id);
            g.Name = temp.Name;
            await Database.Roles.Update(g);

            Database.Save();
        }

        public async Task GiveRoles(List<string> role, string user)
        {
            await Database.Roles.GiveRoles(role, user);
        }

        public async Task TakeAwayRoles(List<string> role, string user)
        {
            await Database.Roles.TakeAwayRoles(role, user);
        }


        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
