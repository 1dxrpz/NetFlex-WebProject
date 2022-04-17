using NetFlex.BLL.Infrastructure;
using NetFlex.BLL.Interfaces;
using NetFlex.BLL.ModelsDTO;
using NetFlex.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using NetFlex.DAL.Entities;

namespace NetFlex.BLL.Services
{
    public class ReviewService : IReviewService
    {
        IUnitOfWork Database { get; set; }

        public ReviewService(IUnitOfWork database)
        {
            Database = database;
        }

        public async Task<IEnumerable<ReviewDTO>> GetReviews()
        {
            var reviews = await Database.Reviews.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Review, ReviewDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Review>, List<ReviewDTO>>(reviews);
        }

        public async Task PublishReview(ReviewDTO reviewDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ReviewDTO, Review>());
            var mapper = new Mapper(config);
            var review = mapper.Map<ReviewDTO, Review>(reviewDTO);

            await Database.Reviews.Create(review);
            Database.Save();
            

            Rating rating = new Rating
            {
                Id = Guid.NewGuid(),
                ContentId = review.ContentId,
                UserRating = review.Rating,
            };

            await Database.Ratings.Create(rating);
            Database.Save();

        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
