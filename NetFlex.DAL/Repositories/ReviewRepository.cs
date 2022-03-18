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

        public IEnumerable<Review> GetAll()
        {
            return _db.Reviews.Include(o => o.Id);
        }

        public Review Get(Guid id)
        {
            return _db.Reviews.Find(id);
        }

        public void Create(Review review)
        {
            _db.Reviews.Add(review);
        }

        public void Update(Review review)
        {
            _db.Entry(review).State = EntityState.Modified;
        }
        public IEnumerable<Review> Find(Func<Review, Boolean> predicate)
        {
            return _db.Reviews.Include(o => o.Id).Where(predicate).ToList();
        }
        public void Delete(Guid id)
        {
            Review order = _db.Reviews.Find(id);
            if (order != null)
                _db.Reviews.Remove(order);
        }
    }
}
