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
        private readonly DatabaseContext _db;

        public UserSubscriptionRepository(DatabaseContext context)
        {
            this._db = context;
        }

        public async Task<IEnumerable<UserSubscription>> GetAll()
        {
            return await _db.UserSubscriptions.ToListAsync();
        }

        public async Task<UserSubscription> Get(Guid id)
        {
            return await _db.UserSubscriptions.FindAsync(id);
        }

        public async Task Create(UserSubscription userSubscription)
        {
            await _db.UserSubscriptions.AddAsync(userSubscription);
        }

        public async Task Update(UserSubscription userSubscription)
        {
            await Task.Run(() =>
            {
                _db.Entry(userSubscription).State = EntityState.Modified;

            });
        }
        public async Task<IEnumerable<UserSubscription>> Find(Func<UserSubscription, Boolean> predicate)
        {
            await Task.Run(() =>
            {
                return _db.UserSubscriptions.Where(predicate).ToList(); 

            });

            return null;
        }
        public async Task Delete(Guid id)
        {
            await Task.Run(() =>
            {
                UserSubscription userSubscription = _db.UserSubscriptions.Find(id);
                if (userSubscription != null)
                    _db.UserSubscriptions.Remove(userSubscription);

            });

           
        }
    }
}
