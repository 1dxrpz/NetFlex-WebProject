using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
    public class EFUnitOfWork : IUnitOfWork
    {
        private DatabaseContext db;

        private EpisodeRepository episodeRepository;
        private FilmRepository filmRepository;
        private SerialRepository serialRepository;
        private RatingRepository ratingRepository;
        private SubscriptionRepository subscriptionRepository;
        private UserSubscriptionRepository userSubscriptionRepository;
        private ReviewRepository reviewRepository;
        private UserRepository userRepository;

        public EFUnitOfWork(DbContextOptions<DatabaseContext> options)
        {
            db = new DatabaseContext(options);

        }

        public IRepository<Episode> Episodes 
        {
            get
            {
                if (episodeRepository == null)
                    episodeRepository = new EpisodeRepository(db);
                return episodeRepository;
            }
        }
        public IRepository<Film> Films
        {
            get
            {
                if (filmRepository == null)
                    filmRepository = new FilmRepository(db);
                return filmRepository;
            }
        }
        public IRepository<Serial> Serials
        {
            get
            {
                if (serialRepository == null)
                    serialRepository = new SerialRepository(db);
                return serialRepository;
            }
        }
        public IRepository<Rating> Ratings
        {
            get
            {
                if (ratingRepository == null)
                    ratingRepository = new RatingRepository(db);
                return ratingRepository;
            }
        }
        public IRepository<Subscription> Subscriptions
        {
            get
            {
                if (subscriptionRepository == null)
                    subscriptionRepository = new SubscriptionRepository(db);
                return subscriptionRepository;
            }
        }
        public IRepository<UserSubscription> UserSubscriptions
        {
            get
            {
                if (userSubscriptionRepository == null)
                    userSubscriptionRepository = new UserSubscriptionRepository(db);
                return userSubscriptionRepository;
            }
        }

        public IRepository<Review> Reviews
        {
            get
            {
                if (reviewRepository == null)
                    reviewRepository = new ReviewRepository(db);
                return reviewRepository;
            }
        }
        public IRepository<ApplicationUser> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
