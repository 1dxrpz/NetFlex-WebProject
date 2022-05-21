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
        Task<IEnumerable<RatingDTO>> GetRatings();
        Task SetRating(ReviewDTO model);
        void Dispose();
    }
}
