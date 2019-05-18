using System.ComponentModel.DataAnnotations;

namespace MakeCurriculum.Models
{
    public class PersonalData
    {
        public int Id { get; set; }

        [Display(Name="Nome")]
        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(100, ErrorMessage = "use até {1} caracteres")]
        public string Name { get; set; }

        [StringLength(20, ErrorMessage = "use até {1} caracteres")]
        [Display(Name = "Nacionalidade")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        [Display(Name = "Idade")]
        [Range(16, 80, ErrorMessage ="idade inválida")]
        public int Age { get; set; }

        [StringLength(50, ErrorMessage = "use até {1} caracteres")]
        [EmailAddress(ErrorMessage = "email inválido")]
        public string Email { get; set; }

        [StringLength(50, ErrorMessage = "use até {1} caracteres")]
        [Url(ErrorMessage ="url inválida")]
        public string Site { get; set; }

        [Display(Name = "Estado Civil")]
        [StringLength(15, ErrorMessage = "use até {1} caracteres")]
        public string CivilStatus { get; set; }

        [Display(Name = "Endereço")]
        [StringLength(100, ErrorMessage = "use até {1} caracteres")]
        public string Adress { get; set; }

        [Display(Name = "Telefone(s)")]
        [StringLength(50, ErrorMessage = "use até {1} caracteres")]
        public string Phone { get; set; }

        public int CurriculumId { get; set; }

        public Curriculum Curriculum { get; set; }
    }
}
