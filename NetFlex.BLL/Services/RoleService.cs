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

        public async Task Create(string role)
        {
            var identityRole = new IdentityRole(role); 

            await Database.Roles.Create(identityRole);
            Database.Save();
        }

        public async Task Delete(string role)
        {
            var res = Database.Roles.Get(role);
            
            await Database.Roles.Delete(res);
            Database.Save();
            
        }

        public async Task Update(RoleDTO editedRole)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RoleDTO, IdentityRole>());
            var mapper = new Mapper(config);
            var temp = mapper.Map<RoleDTO, IdentityRole>(editedRole);

            var g = Database.Roles.Get(editedRole.Name);
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
