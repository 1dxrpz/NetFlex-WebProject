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

        public IEnumerable<Episode> GetAll()
        {
            return _db.Episodes.Include(o => o.Title);
        }

        public Episode Get(Guid id)
        {
            return _db.Episodes.Find(id);
        }

        public void Create(Episode episode)
        {
            _db.Episodes.Add(episode);
        }

        public void Update(Episode episode)
        {
            _db.Entry(episode).State = EntityState.Modified;
        }
        public IEnumerable<Episode> Find(Func<Episode, Boolean> predicate)
        {
            return _db.Episodes.Include(o => o.Title).Where(predicate).ToList();
        }
        public void Delete(Guid id)
        {
            Episode episode = _db.Episodes.Find(id);
            if (episode != null)
                _db.Episodes.Remove(episode);
        }

        
    }
}
