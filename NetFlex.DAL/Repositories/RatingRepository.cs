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
    public class RatingRepository : IRepository<Rating>
    {
        private readonly DatabaseContext _db;

        public RatingRepository(DatabaseContext context)
        {
            this._db = context;
        }

        public async Task<IEnumerable<Rating>> GetAll()
        {
            return await _db.Ratings.ToListAsync();
        }

        public async Task<Rating> Get(Guid id)
        {
            return await _db.Ratings.FindAsync(id);
        }

        public async Task Create(Rating rating)
        {
            await _db.Ratings.AddAsync(rating);
        }

        public async Task Update(Rating rating)
        {
            await Task.Run(() =>
            {
                _db.Entry(rating).State = EntityState.Modified;

            });

        }

        public async Task<IEnumerable<Rating>> Find(Func<Rating, Boolean> predicate)
        {
            await Task.Run(() =>
            {
                return _db.Ratings.Where(predicate).ToList();

            });

            return null;
        }

        public async Task Delete(Guid id)
        {
            await Task.Run(() =>
            {
                Rating rating = _db.Ratings.Find(id);
                if (rating != null)
                    _db.Ratings.Remove(rating);
            });
            
        }
    }
}
