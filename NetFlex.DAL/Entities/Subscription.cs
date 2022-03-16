using NetFlex.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.DAL.Entities
{
    public class Subscription
    {
        public SubscriptionType id { get; set; }
        public string Name { get; set; }

        public int Cost { get; set; }
    }
}
