using Microsoft.AspNetCore.Identity;
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
        IEnumerable<IdentityRole> GetAll();
        IdentityRole Get(string Name);
        Task Create(IdentityRole name);
        Task Delete(IdentityRole name);
        Task GiveRole(string role, string user);
        Task TakeAwayRole(string role, string user);

    }
}
