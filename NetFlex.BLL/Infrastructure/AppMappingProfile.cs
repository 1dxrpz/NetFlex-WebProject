using AutoMapper;
using NetFlex.BLL.ModelsDTO;
using NetFlex.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.BLL.Infrastructure
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<Film, FilmDTO>().ReverseMap();
        }
    }
}
