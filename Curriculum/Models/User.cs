using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeCurriculum.Models
{
    public class User
    {
        public int Id { get; set; }

        [Remote("UserExist", "Users")]
        [Required(ErrorMessage ="campo obrigatório")]
        [StringLength(50, ErrorMessage ="use até {1} caracteres")]
        [EmailAddress(ErrorMessage ="email inválido")]
        public string Email { get; set; }

        [NotMapped]
        [Display(Name = "Confirmar email")]
        [Compare("Email", ErrorMessage ="emails não correspodem")]
        [EmailAddress(ErrorMessage = "email inválido")]
        public string EmailConf { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(10, ErrorMessage = "use até {1} caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "senhas não correspodem")]
        [DataType(DataType.Password)]
        public string PasswordConf { get; set; }

        public ICollection<LoginInformation> LoginInformations { get; set; }

        public ICollection<Curriculum> Curriculums { get; set; }
    }
}
