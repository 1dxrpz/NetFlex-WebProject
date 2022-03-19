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
    public class UserRepository : IRepository<ApplicationUser>
    {
        private readonly DatabaseContext _db;

        public UserRepository(DatabaseContext context)
        {
            this._db = context;
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _db.Users;
        }

        public ApplicationUser Get(Guid id)
        {
            return _db.Users.Find(id);
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
        public void Delete(Guid id)
        {
            ApplicationUser users = _db.Users.Find(id);
            if (users != null)
                _db.Users.Remove(users);
        }
    }
}
