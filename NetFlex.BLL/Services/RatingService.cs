using NetFlex.BLL.Interfaces;
using NetFlex.BLL.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetFlex.BLL.BusinessModels;
using AutoMapper;
using NetFlex.DAL.Entities;
using NetFlex.DAL.Interfaces;
using NetFlex.BLL.Infrastructure;

namespace NetFlex.BLL.Services
{
    public class RatingService : IRatingService
    {
        
        IUnitOfWork Database { get; set; }

        public RatingService(IUnitOfWork database)
        {
            Database = database;
        }

        public IEnumerable<RatingDTO> GetRatings()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Rating, RatingDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Rating>, List<RatingDTO>>(Database.Ratings.GetAll());
        }

        public void SetRating(ReviewDTO model)
        {
            var calc = new CalculateRating(GetRatings());
            var rating = calc.CalcRating(model.ContentId);

            Film filmRating = null;
            Serial serialRating = null;

            filmRating = Database.Films.Get(model.ContentId);
            filmRating.UserRating = rating;

            if (filmRating == null)
            {
                serialRating = Database.Serials.Get(model.ContentId);
                serialRating.UserRating = rating;

                if (serialRating == null)
                {
                    throw new ValidationException("Видео не найдено", "");
                }
            }

            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        
    }
}
