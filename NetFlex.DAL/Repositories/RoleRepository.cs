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
        private readonly DatabaseContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RoleRepository(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, DatabaseContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }

        public IQueryable<IdentityRole> GetAll()
        {
            return (IQueryable<IdentityRole>)_db.Roles;
        }

        public IdentityRole Get(string name)
        {
            return (IdentityRole)_db.Roles.Select(r => r.Name == name);
        }

        public void Create(IdentityRole role)
        {
            _roleManager.Create(role);
        }

        public void GiveRole(string role, string userName)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == userName);
            _userManager.AddToRole(user.Id, role);
        }
        public void TakeAwayRole(string role, string userName)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == userName);
            _userManager.RemoveFromRole(user.Id, role);
        }

        public void Delete(IdentityRole role)
        {
            _roleManager.Delete(role);
        }
    }
}
