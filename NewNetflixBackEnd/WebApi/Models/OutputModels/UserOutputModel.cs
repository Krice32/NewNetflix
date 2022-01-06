namespace WebApi.Models.OutputModels
{
    public class UserOutputModel
    {
        public int UsrId { get; set; }
        public string UsrName { get; set; } = null!;
        public string UsrEmail { get; set; } = null!;
        public string UsrPassword { get; set; } = null!;
    }
}
