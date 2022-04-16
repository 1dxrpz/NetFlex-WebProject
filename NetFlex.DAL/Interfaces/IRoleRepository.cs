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
        Task Update(IdentityRole role);
        Task GiveRoles(List<string> role, string user);
        Task TakeAwayRoles(List<string> role, string user);

    }
}
