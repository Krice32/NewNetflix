using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class VwMoviesGenre
    {
        public string? MvTitle { get; set; }
        public string? MvDate { get; set; }
        public string? Genre { get; set; }
        public string? MvImg { get; set; }
        public int? MvDuration { get; set; }
        public string? MvSynopsis { get; set; }
    }
}
