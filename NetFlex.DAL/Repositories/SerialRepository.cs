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
        private readonly DatabaseContext db;

        public SerialRepository(DatabaseContext context)
        {
            this.db = context;
        }

        public IEnumerable<Serial> GetAll()
        {
            return db.Serials.Include(o => o.Title);
        }

        public Serial Get(Guid id)
        {
            return db.Serials.Find(id);
        }

        public void Create(Serial serial)
        {
            db.Serials.Add(serial);
        }

        public void Update(Serial serial)
        {
            db.Entry(serial).State = EntityState.Modified;
        }

        public IEnumerable<Serial> Find(Func<Serial, Boolean> predicate)
        {
            return db.Serials.Include(o => o.Title).Where(predicate).ToList();
        }

        public void Delete(Guid id)
        {
            Serial serial = db.Serials.Find(id);
            if (serial != null)
                db.Serials.Remove(serial);
        }
    }
}
