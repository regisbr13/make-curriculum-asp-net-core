using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(10, ErrorMessage = "use até {1} caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public ICollection<LoginInformation> LoginInformations { get; set; }

        public ICollection<Curriculum> Curriculums { get; set; }
    }
}
