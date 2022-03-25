using Microsoft.AspNet.Identity.EntityFramework;
using NetFlex.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.DAL.Interfaces
{
    public interface IRoleRepository
    {
        IQueryable<IdentityRole> GetAll();
        IdentityRole Get(string Name);
        void Create(string name);
        void Delete(string name);
    }
}
