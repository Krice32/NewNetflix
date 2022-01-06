using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class UserWatch
    {
        public int UsrWatchId { get; set; }
        public int? UsrId { get; set; }
        public int? MvId { get; set; }
        public int? SeId { get; set; }
        public bool? Watched { get; set; }

        public virtual Movie? Mv { get; set; }
        public virtual Series? Se { get; set; }
        public virtual User? Usr { get; set; }
    }
}
