using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Models
{
    public class ExtraActivity
    {
        public int Id { get; set; }

        [Display(Name = "Curso/Atividade")]
        [StringLength(50, ErrorMessage = "use até {1} caracteres")]
        public string CourseName { get; set; }

        [Display(Name = "Informações")]
        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(300, ErrorMessage = "use até {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Info { get; set; }

        public int CurriculumId { get; set; }

        public Curriculum Curriculum { get; set; }
    }
}
