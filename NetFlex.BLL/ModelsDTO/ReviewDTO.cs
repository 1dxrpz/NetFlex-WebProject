using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.BLL.ModelsDTO
{
    public class ReviewDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public Guid ContentId { get; set; }
        public float Rating { get; set; }
        public DateTime PublishTime { get; set; }
    }
}
