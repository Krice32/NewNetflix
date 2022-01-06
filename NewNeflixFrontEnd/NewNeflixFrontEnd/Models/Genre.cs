namespace NewNeflixFrontEnd.Models
{
    public class Genre
    {
        public Genre()
        {
            Movie = new HashSet<Movie>();
        }

        public int GrId { get; set; }
        public string Genre1 { get; set; } = null!;

        public virtual ICollection<Movie> Movie { get; set; }
    }
}
