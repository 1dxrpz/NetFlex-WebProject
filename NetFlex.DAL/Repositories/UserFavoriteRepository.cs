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
    public class UserFavoriteRepository : IRepository<UserFavorite>
    {
        private readonly DatabaseContext _db;

        public UserFavoriteRepository(DatabaseContext context)
        {
            this._db = context;
        }

        public  IEnumerable<UserFavorite> GetAll()
        {
            return _db.UserFavorites;
        }

        public UserFavorite Get(Guid id)
        {
            return _db.UserFavorites.Find(id);
        }

        public void Create(UserFavorite favorite)
        {
            _db.UserFavorites.Add(favorite);
        }

        public void Update(UserFavorite favorite)
        {
            _db.Entry(favorite).State = EntityState.Modified;
        }

        public IEnumerable<UserFavorite> Find(Func<UserFavorite, Boolean> predicate)
        {
            return _db.UserFavorites.Include(o => o.UserId).Where(predicate).ToList();
        }

        public void Delete(Guid id)
        {
            UserFavorite favorite = _db.UserFavorites.FirstOrDefault(f => f.ContentId == id);
            if (favorite != null)
                _db.UserFavorites.Remove(favorite);
        }
    }
}
