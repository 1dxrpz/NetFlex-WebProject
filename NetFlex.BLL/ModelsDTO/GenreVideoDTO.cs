using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.BLL.ModelsDTO
{
    public class GenreVideoDTO
    {
        public Guid Id {get; set;}
        public Guid ContentId { get; set; }
        public string GenreName { get; set; }
    }
}
