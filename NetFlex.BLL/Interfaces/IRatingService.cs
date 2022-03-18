using NetFlex.BLL.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.BLL.Interfaces
{
    public interface IRatingService
    {
        IEnumerable<RatingDTO> GetRatings();
        void SetRating(RatingDTO model);
        void Dispose();
    }
}
