using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class VwSeriesGenre
    {
        public string? SeTitle { get; set; }
        public string? SeDate { get; set; }
        public string? Genre { get; set; }
        public string? SeImg { get; set; }
        public int? SeQtdSeasons { get; set; }
        public string? SeSynopsis { get; set; }
    }
}
