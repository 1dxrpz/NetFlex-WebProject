using NetFlex.BLL.ModelsDTO;
using NetFlex.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.BLL.Interfaces
{
    public interface IReviewService
    {
        IEnumerable<ReviewDTO> GetReviews();
        Task PublishReview(ReviewDTO model);
        void Dispose();
    }
}
