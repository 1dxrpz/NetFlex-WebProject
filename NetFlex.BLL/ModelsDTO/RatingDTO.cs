using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.BLL.ModelsDTO
{
    public class RatingDTO
    {
        public Guid UserId { get; set; }
        public Guid ContentId { get; set; }
        public int UserRating { get; set; }
    }
}


