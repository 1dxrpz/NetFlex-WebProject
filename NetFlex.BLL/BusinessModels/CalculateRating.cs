using NetFlex.BLL.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.BLL.BusinessModels
{
    public class CalculateRating
    {
        private IEnumerable<RatingDTO> _ratingList;
        public CalculateRating(IEnumerable<RatingDTO> ratingList)
        {
            _ratingList = ratingList;
        }

        public float CalcRating(Guid contentId)
        {
            var rating = _ratingList.Where(r => r.ContentId == contentId).ToList();
            float res = 0;
            foreach (var e in rating)
            {

                res += e.UserRating;
            }
            res /= rating.Count;
            return res;
        }
    }
}
