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

        public async Task<IEnumerable<UserFavorite>> GetAll()
        {
            return await _db.UserFavorites.ToListAsync();
        }

        public async Task<UserFavorite> Get(Guid id)
        {
            return await _db.UserFavorites.FindAsync(id);
        }

        public async Task Create(UserFavorite favorite)
        {
            await _db.UserFavorites.AddAsync(favorite);
        }

        public async Task Update(UserFavorite favorite)
        {
            await Task.Run(() =>
            {
                _db.Entry(favorite).State = EntityState.Modified;

            });
        }

        public async Task <IEnumerable<UserFavorite>> Find(Func<UserFavorite, Boolean> predicate)
        {
            await Task.Run(() =>
            {
                return _db.UserFavorites.Include(o => o.UserId).Where(predicate).ToList();

            });

            return null;
        }

        public async Task Delete(Guid id)
        {
            await Task.Run(() =>
            {
                UserFavorite favorite = _db.UserFavorites.FirstOrDefault(f => f.ContentId == id);
                if (favorite != null)
                    _db.UserFavorites.Remove(favorite);

            });
            
        }
    }
}
