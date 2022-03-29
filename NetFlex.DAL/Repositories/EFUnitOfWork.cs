using Microsoft.AspNetCore.Identity;
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
        private DatabaseContext _db;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;

        private EpisodeRepository _episodeRepository;
        private FilmRepository _filmRepository;
        private SerialRepository _serialRepository;
        private RatingRepository _ratingRepository;
        private SubscriptionRepository _subscriptionRepository;
        private UserSubscriptionRepository _userSubscriptionRepository;
        private ReviewRepository _reviewRepository;
        private UserRepository _userRepository;
        private RoleRepository _roleRepository;

        public EFUnitOfWork(DbContextOptions<DatabaseContext> options, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _db = new DatabaseContext(options);
            _roleManager = roleManager;
            _userManager = userManager;

        }

        public IRepository<Episode> Episodes
        {
            get
            {
                if (_episodeRepository == null)
                    _episodeRepository = new EpisodeRepository(_db);
                return _episodeRepository;
            }
        }
        public IRepository<Film> Films
        {
            get
            {
                if (_filmRepository == null)
                    _filmRepository = new FilmRepository(_db);
                return _filmRepository;
            }
        }
        public IRepository<Serial> Serials
        {
            get
            {
                if (_serialRepository == null)
                    _serialRepository = new SerialRepository(_db);
                return _serialRepository;
            }
        }
        public IRepository<Rating> Ratings
        {
            get
            {
                if (_ratingRepository == null)
                    _ratingRepository = new RatingRepository(_db);
                return _ratingRepository;
            }
        }
        public IRepository<Subscription> Subscriptions
        {
            get
            {
                if (_subscriptionRepository == null)
                    _subscriptionRepository = new SubscriptionRepository(_db);
                return _subscriptionRepository;
            }
        }
        public IRepository<UserSubscription> UserSubscriptions
        {
            get
            {
                if (_userSubscriptionRepository == null)
                    _userSubscriptionRepository = new UserSubscriptionRepository(_db);
                return _userSubscriptionRepository;
            }
        }
        public IRepository<Review> Reviews
        {
            get
            {
                if (_reviewRepository == null)
                    _reviewRepository = new ReviewRepository(_db);
                return _reviewRepository;
            }
        }
        public IRepository<ApplicationUser> Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_db);
                return _userRepository;
            }
        }
        public IRoleRepository Roles
        {
            get
            {
                if (_roleRepository == null)
                    _roleRepository = new RoleRepository(_roleManager, _userManager, _db);
                return _roleRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
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
