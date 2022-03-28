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
        IQueryable<RoleDTO> GetRoles();
        RoleDTO Get(string role);

        void Create(RoleDTO role);
        void Delete(string role);
        void GiveRole(string role, string user);
        void TakeAwayRole(string role, string user);

        void Dispose();


    }
}
