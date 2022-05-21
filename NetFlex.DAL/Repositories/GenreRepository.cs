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

        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await _db.Genres.ToListAsync();
        }

        public async Task<Genre> Get(Guid id)
        {
            return await _db.Genres.FindAsync(id);
        }

        public async Task Create(Genre genre)
        {
           await _db.Genres.AddAsync(genre);
        }

        public async Task Update(Genre genre)
        {
            await Task.Run(() =>
            {
                _db.Entry(genre).State = EntityState.Modified;

            });
        }
        public async Task<IEnumerable<Genre>> Find(Func<Genre, Boolean> predicate)
        {
            await Task.Run(() =>
            {
                return _db.Genres.Include(o => o.Id).Where(predicate).ToList();

            });
            return null;
        }
        public async Task Delete(Guid id)
        {
            await Task.Run(() =>
            {
                Genre genre = _db.Genres.Find(id);
                if (genre != null)
                    _db.Genres.Remove(genre);

            });
        }
    }
}
