using System.ComponentModel.DataAnnotations;

namespace MakeCurriculum.Models.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(50, ErrorMessage = "use até {1} caracteres")]
        [EmailAddress(ErrorMessage = "email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(10, ErrorMessage = "use até {1} caracteres")]
        [DataType(DataType.Password)]   
        public string Password { get; set; }
    }
}
