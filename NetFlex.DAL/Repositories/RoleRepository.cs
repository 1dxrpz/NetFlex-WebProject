using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using NetFlex.DAL.EF;
using NetFlex.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RoleRepository(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IQueryable<IdentityRole> GetAll()
        {
            return _roleManager.Roles;
        }

        public IdentityRole Get(string name)
        {
            return _roleManager.Roles.FirstOrDefault(r => r.Name == name);
        }

        public void Create(string role)
        {
            IdentityResult result = _roleManager.Create(new IdentityRole(role));
        }

        public void SetRole(string role, string user)
        {
            _userManager.AddToRole(role, user);
        }
        public void DeleteRole(string role, string user)
        {
            _userManager.RemoveFromRole(user, role);
        }

        public void Delete(string name)
        {
            IdentityRole role = _roleManager.Roles.FirstOrDefault(r => r.Name == name);
            _roleManager.Delete(role);
        }
    }
}
