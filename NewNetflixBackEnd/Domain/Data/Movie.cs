using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Favorites = new HashSet<Favorite>();
            UserWatches = new HashSet<UserWatch>();
            WatchLaters = new HashSet<WatchLater>();
        }

        public int MvId { get; set; }
        public string MvTitle { get; set; } = null!;
        public string MvDate { get; set; } = null!;
        public string? MvImg { get; set; }
        public int? MvDuration { get; set; }
        public string? MvSynopsis { get; set; }
        public int? GrId { get; set; }

        public virtual Genre? Gr { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<UserWatch> UserWatches { get; set; }
        public virtual ICollection<WatchLater> WatchLaters { get; set; }
    }
}
