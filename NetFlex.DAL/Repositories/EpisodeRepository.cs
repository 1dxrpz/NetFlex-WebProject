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
    public class EpisodeRepository : IRepository<Episode>
    {
        private readonly DatabaseContext _db;

        public EpisodeRepository(DatabaseContext context)
        {
            this._db = context;
        }

        public async Task<IEnumerable<Episode>> GetAll()
        {
            return await _db.Episodes.ToListAsync();
        }

        public async Task<Episode> Get(Guid id)
        {
            return await _db.Episodes.FindAsync(id);
        }

        public async Task Create(Episode episode)
        {
            await _db.Episodes.AddAsync(episode);
        }

        public async Task Update(Episode episode)
        {
            await Task.Run(() =>
            {
                _db.Entry(episode).State = EntityState.Modified;

            });
        }
        public async Task<IEnumerable<Episode>> Find(Func<Episode, Boolean> predicate)
        {
            await Task.Run(() =>
            {
                return _db.Episodes.Include(o => o.Title).Where(predicate).ToList();

            });
            return null;
        }
        public async Task Delete(Guid id)
        {
            await Task.Run(() =>
            {
                Episode episode = _db.Episodes.Find(id);
                if (episode != null)
                    _db.Episodes.Remove(episode);

            });
            
        }

        
    }
}
