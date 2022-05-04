using NetFlex.BLL.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.BLL.Interfaces
{
    public interface ISubscriptionService
    {
        Task<IEnumerable<SubscriptionDTO>> GetSubs();
        Task<SubscriptionDTO> GetSub(string id);
        Task Create(SubscriptionDTO sub);
        Task Delete(string id);
        Task Update(SubscriptionDTO editedSub);
        Task<SubscriptionDTO> GetUserSub(string id);
        Task SetSub(string userId, string subId);
        Task CancelSub(string userId);
        void Dispose();
    }
}
