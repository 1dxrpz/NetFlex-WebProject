using Microsoft.EntityFrameworkCore;
using NetFlex.DAL.EF;
using NetFlex.DAL.Entities;
using NetFlex.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.DAL.Repositories
{
    public class SubscriptionRepository : IRepository<Subscription>
    {
        private readonly DatabaseContext db;

        public SubscriptionRepository(DatabaseContext context)
        {
            this.db = context;
        }

        public IEnumerable<Subscription> GetAll()
        {
            return db.Subscriptions.Include(o => o.Name);
        }

        public Subscription Get(Guid id)
        {
            return db.Subscriptions.Find(id);
        }

        public void Create(Subscription subscription)
        {
            db.Subscriptions.Add(subscription);
        }

        public void Update(Subscription subscription)
        {
            db.Entry(subscription).State = EntityState.Modified;
        }

        public IEnumerable<Subscription> Find(Func<Subscription, Boolean> predicate)
        {
            return db.Subscriptions.Where(predicate).ToList();
        }

        public void Delete(Guid id)
        {
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription != null)
                db.Subscriptions.Remove(subscription);
        }
    }
}
