using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Movies = new HashSet<Movie>();
            Series = new HashSet<Series>();
        }

        public int GrId { get; set; }
        public string Genre1 { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<Series> Series { get; set; }
    }
}
