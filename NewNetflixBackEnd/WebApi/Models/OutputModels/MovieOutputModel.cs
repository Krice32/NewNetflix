namespace WebApi.Models
{
    public class MovieOutputModel
    {
        public int MvId { get; set; }
        public string MvTitle { get; set; } = null!;
        public string MvDate { get; set; } = null!;      
        public int? GrId { get; set; }
    }
}
