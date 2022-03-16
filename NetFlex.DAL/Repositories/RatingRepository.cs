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
        private DatabaseContext db;

        public RatingRepository(DatabaseContext context)
        {
            this.db = context;
        }

        public IEnumerable<Rating> GetAll()
        {
            return db.Ratings;
        }

        public Rating Get(int id)
        {
            return db.Ratings.Find(id);
        }

        public void Create(Rating rating)
        {
            db.Ratings.Add(rating);
        }

        public void Update(Rating rating)
        {
            db.Entry(rating).State = EntityState.Modified;
        }

        public IEnumerable<Rating> Find(Func<Rating, Boolean> predicate)
        {
            return db.Ratings.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Rating rating = db.Ratings.Find(id);
            if (rating != null)
                db.Ratings.Remove(rating);
        }
    }
}
