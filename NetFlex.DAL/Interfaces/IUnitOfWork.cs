using NetFlex.DAL.EF;
using NetFlex.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Episode> Episodes { get; }
        IRepository<Film> Films { get; }
        IRepository<Serial> Serials { get; }
        IRepository<Rating> Ratings { get; }
        IRepository<Subscription> Subscriptions { get; }
        IRepository<UserSubscription> UserSubscriptions { get; }
        IRepository<Review> Reviews { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }


        void Save();
    }
}
