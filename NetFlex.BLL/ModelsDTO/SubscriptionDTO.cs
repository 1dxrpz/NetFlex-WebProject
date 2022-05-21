using NetFlex.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.BLL.ModelsDTO
{
    public class SubscriptionDTO
    {
        public SubscriptionType id { get; set; }
        public string Name { get; set; }

        public float Cost { get; set; }
    }
}
