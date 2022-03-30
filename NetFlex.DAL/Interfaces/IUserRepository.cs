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
        IEnumerable<ApplicationUser> GetAll();
        Task<ApplicationUser> Get(string id);
        IEnumerable<ApplicationUser> Find(Func<ApplicationUser, Boolean> predicate);
        void Create(ApplicationUser item);
        void Update(ApplicationUser item);
        Task<IEnumerable<string>> GetRoles(string userName);
        void Delete(Guid id);
    }
}
