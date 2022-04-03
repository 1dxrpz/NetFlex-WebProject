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

        public IEnumerable<GenreVideo> GetAll()
        {
            return _db.GenreVideos;
        }

        public GenreVideo Get(Guid id)
        {
            return _db.GenreVideos.Find(id);
        }

        public void Create(GenreVideo genre)
        {
            _db.GenreVideos.Add(genre);
        }

        public void Update(GenreVideo genre)
        {
            _db.Entry(genre).State = EntityState.Modified;
        }
        public IEnumerable<GenreVideo> Find(Func<GenreVideo, Boolean> predicate)
        {
            return _db.GenreVideos.Include(o => o.Id).Where(predicate).ToList();
        }
        public void Delete(Guid id)
        {
            Review genreVideo = _db.Reviews.Find(id);
            if (genreVideo != null)
                _db.Reviews.Remove(genreVideo);
        }

    }
}
