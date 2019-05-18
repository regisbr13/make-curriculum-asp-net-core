using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Models
{
    public class Resume
    {
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "descrição obrigatória")]
        [StringLength(1000, ErrorMessage = "use até {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int CurriculumId { get; set; }

        public Curriculum Curriculum { get; set; }
    }
}
