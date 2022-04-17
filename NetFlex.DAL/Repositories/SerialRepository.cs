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
    public class SerialRepository : IRepository<Serial>
    {
        private readonly DatabaseContext _db;

        public SerialRepository(DatabaseContext context)
        {
            this._db = context;
        }

        public async Task<IEnumerable<Serial>> GetAll()
        {
            return await _db.Serials.ToListAsync();
        }

        public async Task<Serial> Get(Guid id)
        {
            return await _db.Serials.FindAsync(id);
        }

        public async Task Create(Serial serial)
        {
            await _db.Serials.AddAsync(serial);
        }

        public async Task Update(Serial serial)
        {
            await Task.Run(() =>
            {
                _db.Entry(serial).State = EntityState.Modified;

            });
            
        }

        public async Task<IEnumerable<Serial>> Find(Func<Serial, Boolean> predicate)
        {
            await Task.Run(() =>
            {
                return _db.Serials.Include(o => o.Title).Where(predicate).ToList();

            });
            return null;
        }

        public async Task Delete(Guid id)
        {
            await Task.Run(() =>
            {
                Serial serial = _db.Serials.Find(id);
                if (serial != null)
                    _db.Serials.Remove(serial);

            });
            
        }
    }
}
