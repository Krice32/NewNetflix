namespace WebApi.Models.InputModels
{
    public class UserInputModel
    {
        public int UsrId { get; set; }
        public string UsrName { get; set; } = null!;
        public string UsrEmail { get; set; } = null!;
        public string UsrPassword { get; set; } = null!;
    }
}
