using System.ComponentModel.DataAnnotations;

namespace NewNeflixFrontEnd.Models
{
    public class Movie
    {
        
        public int MvId { get; set; }

        [Display(Name = "Título")]
        public string MvTitle { get; set; } = null!;
        [Display(Name ="Data de lançamento")]
        public string MvDate { get; set; } = null!;
        [Display(Name ="Imagem")]
        public string? MvImg { get; set; }
        [Display(Name = "Duração")]
        public int? MvDuration { get; set; }
        [Display(Name = "Sinopse")]
        public string? MvSynopsis { get; set; }
        [Display(Name = "Gênero")]
        public int? GrId { get; set; }

        public virtual Genre? Gr { get; set; }
    }
}
