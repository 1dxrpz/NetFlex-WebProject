using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.DAL.Entities
{
    public class Episode
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SerialId { get; set; }
        public string Number { get; set; }
        public string VideoLink { get; set; }

    }
}
