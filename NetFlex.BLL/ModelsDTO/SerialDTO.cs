using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.BLL.ModelsDTO
{
    public class SerialDTO
    {
        public Guid Id { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
        public int NumEpisodes { get; set; }
        public int AgeRating { get; set; }

        public float UserRating { get; set; }
        public string Description { get; set; }
    }
}
