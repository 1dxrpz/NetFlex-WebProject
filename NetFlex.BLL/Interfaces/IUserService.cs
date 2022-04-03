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
        IEnumerable<UserDTO> GetUsers();
        Task<IEnumerable<string>> GetRoles(string userName);

        void AddToMyList(UserFavoriteDTO favorite);

        IEnumerable<UserFavoriteDTO> GetMyList(Guid userId);
        void DeleteFromMyList(Guid favorite);

        void Dispose();
    }
}
