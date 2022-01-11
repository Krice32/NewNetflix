using System.ComponentModel.DataAnnotations;

namespace NewNeflixFrontEnd.Models
{
    public class Series
    {
        public int SeId { get; set; }

        [Display(Name = "Título")]
        public string SeTitle { get; set; } = null!;

        [Display(Name = "Data de lançamento")]
        public string SeDate { get; set; } = null!;

        [Display(Name = "Imagem")]
        public string? SeImg { get; set; }

        [Display(Name = "Temporadas")]
        public int? SeQtdSeasons { get; set; }

        [Display(Name = "Sinopse")]
        public string? SeSynopsis { get; set; }
        [Display(Name = "Gênero")]
        public int? GrId { get; set; }
        [Display(Name = "Gênero")]
        public virtual Genre? Gr { get; set; }
    }
}
