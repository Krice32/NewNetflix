using System.ComponentModel.DataAnnotations;

namespace NewNeflixFrontEnd.Models
{
    public class Users
    {
        public int UsrId { get; set; }

        [Display(Name = "Nome de usuario")]
        public string UsrName { get; set; } = null!;

        [Display(Name = "E-mail")]
     
        public string UsrEmail { get; set; } = null!;

        [Display(Name = "Senha")]
        public string UsrPassword { get; set; } = null!;

     
    }
}
