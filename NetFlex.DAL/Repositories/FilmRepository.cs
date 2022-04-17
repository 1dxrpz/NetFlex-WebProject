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
    public class FilmRepository : IRepository<Film>
    {
        private readonly DatabaseContext _db;

        public FilmRepository(DatabaseContext context)
        {
            this._db = context;
        }

        public async Task<IEnumerable<Film>> GetAll()
        {
            return await _db.Films.ToListAsync();
        }

        public async Task<Film> Get(Guid id)
        {
            return await _db.Films.FindAsync(id);
        }

        public async Task  Create(Film film)
        {
            await _db.Films.AddAsync(film);
        }

        public async Task  Update(Film film)
        {
            await Task.Run(() =>
            {
                _db.Entry(film).State = EntityState.Modified;

            });
            
        }
        public async Task<IEnumerable<Film>> Find(Func<Film, Boolean> predicate)
        {
            await Task.Run(() =>
            {
                return _db.Films.Include(o => o.Title).Where(predicate).ToList();

            });


            return null;
        }
        public async Task Delete(Guid id)
        {
            await Task.Run(() =>
            {
                Film order = _db.Films.Find(id);
                if (order != null)
                    _db.Films.Remove(order);

            });
            
        }
    }
}
