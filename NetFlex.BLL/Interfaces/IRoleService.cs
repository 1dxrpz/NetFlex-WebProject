using NetFlex.BLL.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.BLL.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<RoleDTO> GetRoles();
        RoleDTO Get(string role);

        Task Create(RoleDTO role);
        Task Delete(string role);
        Task GiveRole(string role, string user);
        Task TakeAwayRole(string role, string user);

        void Dispose();


    }
}
