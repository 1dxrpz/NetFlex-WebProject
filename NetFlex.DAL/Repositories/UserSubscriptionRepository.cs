using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetFlex.DAL.EF;
using NetFlex.DAL.Entities;
using NetFlex.DAL.Interfaces;

namespace NetFlex.DAL.Repositories
{
    public class UserSubscriptionRepository : IRepository<UserSubscription>
    {
        private DatabaseContext _db;

        public UserSubscriptionRepository(DatabaseContext context)
        {
            this._db = context;
        }

        public IEnumerable<UserSubscription> GetAll()
        {
            return _db.UserSubscriptions;
        }

        public UserSubscription Get(int id)
        {
            return _db.UserSubscriptions.Find(id);
        }

        public void Create(UserSubscription userSubscription)
        {
            _db.UserSubscriptions.Add(userSubscription);
        }

        public void Update(UserSubscription userSubscription)
        {
            _db.Entry(userSubscription).State = EntityState.Modified;
        }
        public IEnumerable<UserSubscription> Find(Func<UserSubscription, Boolean> predicate)
        {
            return _db.UserSubscriptions.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            UserSubscription userSubscription = _db.UserSubscriptions.Find(id);
            if (userSubscription != null)
                _db.UserSubscriptions.Remove(userSubscription);
        }
    }
}
