using NetFlex.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAll();
        Task<ApplicationUser> Get(string id);
        Task<IEnumerable<ApplicationUser>> Find(Func<ApplicationUser, Boolean> predicate);
        Task Create(ApplicationUser item);
        Task Update(ApplicationUser item);
        Task<IEnumerable<string>> GetRoles(string userName);
        Task Delete(Guid id);
    }
}
