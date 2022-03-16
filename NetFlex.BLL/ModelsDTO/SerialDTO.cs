using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.DAL.Entities
{
    public class SerialDTO
    {
        public Guid Id { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
        public string NumEpisodes { get; set; }
        public string AgeRating { get; set; }
        public string UserRating { get; set; }
        public string Description { get; set; }
    }
}
