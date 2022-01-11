namespace NewNeflixFrontEnd.Models
{
    public class Genre
    {
        public Genre()
        {
            Movie = new HashSet<Movie>();
            Series = new HashSet<Series>();
        }

        public int GrId { get; set; }
        public string Genre1 { get; set; } = null!;

        public virtual ICollection<Movie> Movie { get; set; }
        public virtual ICollection<Series> Series { get; set; }

    }
}
