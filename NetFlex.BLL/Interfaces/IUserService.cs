using Microsoft.AspNet.Identity.EntityFramework;
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
        Task<UserDTO> GetUser(string id);
        Task<IEnumerable<UserDTO>> GetUsers();
        Task<IEnumerable<string>> GetRoles(string userName);

        Task AddToMyList(UserFavoriteDTO favorite);

        Task<IEnumerable<UserFavoriteDTO>> GetMyList(Guid userId);
        Task DeleteFromMyList(Guid favorite);

        void Dispose();
    }
}
