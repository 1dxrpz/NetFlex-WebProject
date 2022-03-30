using Microsoft.AspNetCore.Identity;
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
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(UserManager<ApplicationUser> userManager, DatabaseContext context)
        {
            _db = context;
            _userManager = userManager;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _db.Users;
        }

        public async Task<ApplicationUser> Get(string id)
        {
            return await _userManager.FindByIdAsync(id); ;
        }

        public void Create(ApplicationUser userSubscription)
        {
            _db.Users.Add(userSubscription);
        }

        public void Update(ApplicationUser userSubscription)
        {
            _db.Entry(userSubscription).State = EntityState.Modified;
        }
        public IEnumerable<ApplicationUser> Find(Func<ApplicationUser, Boolean> predicate)
        {
            return _db.Users.Where(predicate).ToList();
        }

        public async Task<IEnumerable<string>> GetRoles(string userName)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == userName);

            return await _userManager.GetRolesAsync(user);
        }

        public void Delete(Guid id)
        {
            ApplicationUser users = _db.Users.Find(id);
            if (users != null)
                _db.Users.Remove(users);
        }
    }
}
