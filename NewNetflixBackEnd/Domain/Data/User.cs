using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class User
    {
        public User()
        {
            Favorites = new HashSet<Favorite>();
            UserWatches = new HashSet<UserWatch>();
            WatchLaters = new HashSet<WatchLater>();
        }

        public int UsrId { get; set; }
        public string UsrName { get; set; } = null!;
        public string UsrEmail { get; set; } = null!;
        public string UsrPassword { get; set; } = null!;

        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<UserWatch> UserWatches { get; set; }
        public virtual ICollection<WatchLater> WatchLaters { get; set; }
    }
}
