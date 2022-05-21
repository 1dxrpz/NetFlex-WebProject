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
        Task<IEnumerable<ReviewDTO>> GetReviews();
        Task<IEnumerable<ReviewDTO>> GetReviews(Guid id);
        Task PublishReview(ReviewDTO model);
        void Dispose();
    }
}
