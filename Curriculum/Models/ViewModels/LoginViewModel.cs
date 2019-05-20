using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MakeCurriculum.Models.ViewModels
{
    public class LoginViewModel
    {
        [Remote("EmailError", "Users")]
        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(50, ErrorMessage = "use até {1} caracteres")]
        [EmailAddress(ErrorMessage = "email inválido")]
        public string Email { get; set; }

        [Remote("PasswordError", "Users")]
        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(10, ErrorMessage = "use até {1} caracteres")]
        [DataType(DataType.Password)]   
        public string Password { get; set; }
    }
}
