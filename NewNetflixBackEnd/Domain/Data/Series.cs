using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Series
    {
        public Series()
        {
            Favorites = new HashSet<Favorite>();
            UserWatches = new HashSet<UserWatch>();
            WatchLaters = new HashSet<WatchLater>();
        }

        public int SeId { get; set; }
        public string SeTitle { get; set; } = null!;
        public string SeDate { get; set; } = null!;
        public string? SeImg { get; set; }
        public int? SeQtdSeasons { get; set; }
        public string? SeSynopsis { get; set; }
        public int? GrId { get; set; }

        public virtual Genre? Gr { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<UserWatch> UserWatches { get; set; }
        public virtual ICollection<WatchLater> WatchLaters { get; set; }
   
    }
}
