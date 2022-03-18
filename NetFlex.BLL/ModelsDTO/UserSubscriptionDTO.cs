using NetFlex.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.BLL.ModelsDTO
{
    public class UserSubscriptionDTO
    {
        public Guid UserId { get; set; }
        public SubscriptionType SubscriptionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }


    }
}
