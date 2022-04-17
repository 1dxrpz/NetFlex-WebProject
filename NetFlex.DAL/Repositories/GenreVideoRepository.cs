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
    public class GenreVideoRepository : IRepository<GenreVideo>
    {
        private readonly DatabaseContext _db;

        public GenreVideoRepository(DatabaseContext context)
        {
            this._db = context;
        }

        public async Task<IEnumerable<GenreVideo>> GetAll()
        {
            return await _db.GenreVideos.ToListAsync();
        }

        public async Task<GenreVideo> Get(Guid id)
        {
            return await _db.GenreVideos.FindAsync(id);
        }

        public async Task Create(GenreVideo genre)
        {
           await _db.GenreVideos.AddAsync(genre);
        }

        public async Task Update(GenreVideo genre)
        {
            await Task.Run(() =>
            {
                _db.Entry(genre).State = EntityState.Modified;

            });
            
        }
        public async Task<IEnumerable<GenreVideo>> Find(Func<GenreVideo, Boolean> predicate)
        {
            await Task.Run(() =>
            {
                return _db.GenreVideos.Include(o => o.Id).Where(predicate).ToList();

            });

            return null;
        }
        public async Task Delete(Guid id)
        {
            await Task.Run(() =>
            {
                Review genreVideo = _db.Reviews.Find(id);
                if (genreVideo != null)
                    _db.Reviews.Remove(genreVideo);

            });
        }

    }
}
