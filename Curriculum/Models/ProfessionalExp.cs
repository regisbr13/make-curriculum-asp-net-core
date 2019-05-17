using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Models
{
    public class ProfessionalExp
    {
        public int Id { get; set; }

        [Display(Name ="Empresa")]
        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(50, ErrorMessage = "use até {1} caracteres")]
        public string Company { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(50, ErrorMessage = "use até {1} caracteres")]
        public string Role { get; set; }

        [Display(Name = "Ano de início")]
        [Required(ErrorMessage = "campo obrigatório")]
        [Range(1920, 2019, ErrorMessage = "ano inválido")]
        public int StartYear { get; set; }

        [Display(Name = "Ano de término")]
        [Required(ErrorMessage = "campo obrigatório")]
        [Range(1920, 2019, ErrorMessage = "ano inválido")]
        public int EndYear { get; set; }

        [Display(Name = "Atividades")]
        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(500, ErrorMessage = "use até {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Activities { get; set; }

        public int CurriculumId { get; set; }

        public Curriculum Curriculum { get; set; }
    }
}
