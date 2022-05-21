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
    public class ReviewRepository : IRepository<Review>
    {
        private readonly DatabaseContext _db;

        public ReviewRepository(DatabaseContext context)
        {
            this._db = context;
        }

        public async Task<IEnumerable<Review>> GetAll()
        {
            return await _db.Reviews.ToListAsync();
        }

        public async Task<Review> Get(Guid id)
        {
            return await _db.Reviews.FindAsync(id);
        }

        public async Task Create(Review review)
        {
            await _db.Reviews.AddAsync(review);
        }

        public async Task Update(Review review)
        {
            await Task.Run(() =>
            {
                _db.Entry(review).State = EntityState.Modified;

            });

        }
        public async Task<IEnumerable<Review>> Find(Func<Review, Boolean> predicate)
        {
            await Task.Run(() =>
            {
                return _db.Reviews.Include(o => o.Id).Where(predicate).ToList();

            });

            return null;
        }
        public async Task Delete(Guid id)
        {
            await Task.Run(() =>
            {
                Review order = _db.Reviews.Find(id);
                if (order != null)
                    _db.Reviews.Remove(order);

            });
            
        }
    }
}
