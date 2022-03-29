using Microsoft.AspNetCore.Identity;
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
        private readonly DatabaseContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleRepository(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, DatabaseContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        public IEnumerable<IdentityRole> GetAll()
        {
            return _roleManager.Roles.ToList();
        }

        public IdentityRole Get(string name)
        {
            return _db.Roles.FirstOrDefault(r => r.Name == name);
        }

        public async Task Create(IdentityRole role)
        {
            await _roleManager.CreateAsync(role);
        }

        public async Task GiveRole(string role, string userName)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == userName);
            await _userManager.AddToRoleAsync(user, role);
        }
        public async Task TakeAwayRole(string role, string userName)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == userName);
            await _userManager.RemoveFromRoleAsync(user, role);
        }

        public async Task Delete(IdentityRole role)
        {
            await _roleManager.DeleteAsync(role);
        }
    }
}
