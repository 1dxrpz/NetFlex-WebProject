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
        void AddRole(RoleDTO roleDTO);
        RoleDTO GetRole(string name);
        IEnumerable<RoleDTO> GetRoles();
        void Dispose();


    }
}
