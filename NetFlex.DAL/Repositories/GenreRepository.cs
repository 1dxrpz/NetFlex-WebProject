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
    public class GenreRepository : IRepository<Genre>
    {
        private readonly DatabaseContext _db;

        public GenreRepository(DatabaseContext context)
        {
            this._db = context;
        }

        public IEnumerable<Genre> GetAll()
        {
            return _db.Genres;
        }

        public Genre Get(Guid id)
        {
            return _db.Genres.Find(id);
        }

        public void Create(Genre genre)
        {
            _db.Genres.Add(genre);
        }

        public void Update(Genre genre)
        {
            _db.Entry(genre).State = EntityState.Modified;
        }
        public IEnumerable<Genre> Find(Func<Genre, Boolean> predicate)
        {
            return _db.Genres.Include(o => o.Id).Where(predicate).ToList();
        }
        public void Delete(Guid id)
        {
            Review genre = _db.Reviews.Find(id);
            if (genre != null)
                _db.Reviews.Remove(genre);
        }
    }
}
