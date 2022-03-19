using NetFlex.BLL.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.BLL.Interfaces
{
    public interface IUserService
    {
        UserDTO GetUser(Guid id);
        IEnumerable<UserDTO> GetUsers();
        void Dispose();
    }
}
