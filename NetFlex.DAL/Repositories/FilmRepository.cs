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
        private DatabaseContext _db;

        public FilmRepository(DatabaseContext context)
        {
            this._db = context;
        }

        public IEnumerable<Film> GetAll()
        {
            return _db.Films.Include(o => o.Title);
        }

        public Film Get(int id)
        {
            return _db.Films.Find(id);
        }

        public void Create(Film film)
        {
            _db.Films.Add(film);
        }

        public void Update(Film film)
        {
            _db.Entry(film).State = EntityState.Modified;
        }
        public IEnumerable<Film> Find(Func<Film, Boolean> predicate)
        {
            return _db.Films.Include(o => o.Title).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Film order = _db.Films.Find(id);
            if (order != null)
                _db.Films.Remove(order);
        }
    }
}
