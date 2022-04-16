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

        Task Create(string role);
        Task Delete(string role);
        Task Update(RoleDTO editedRole);
        Task GiveRoles(List<string> role, string user);
        Task TakeAwayRoles(List<string> role, string user);
        void Dispose();


    }
}
