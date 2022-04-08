using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFlex.DAL.Entities
{
    public class GenreVideo
    {
        public Guid Id { get; set; }
        public string GenreName { get; set; }
        public Guid ContentId { get; set; }
    }
}
