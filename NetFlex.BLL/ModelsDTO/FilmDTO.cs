using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.BLL.ModelsDTO
{
    public class FilmDTO
    {
        public Guid Id { get; set; }
        public string Poster { get; set; }


        public string Title { get; set; }
        public int Duration { get; set; }
        public int AgeRating { get; set; }
        public float UserRating { get; set; }
        public string Description { get; set; }
        public string VideoLink { get; set; }
       
        public string Preview { get; set; }
    }
}
