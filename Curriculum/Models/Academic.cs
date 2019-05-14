using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Models
{
    public class Academic
    {
        public int Id { get; set; }

        public int CoursesTypeId { get; set; }

        public CoursesType CoursesType { get; set; }

        [Required(ErrorMessage ="campo obrigatório")]
        [StringLength(50, ErrorMessage ="use até {1} caracteres")]
        public string Institution { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        [Range(1920, 2019, ErrorMessage ="ano inválido")]
        public int StartYear { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        [Range(1920, 2024, ErrorMessage = "ano inválido")]
        public int EndYear { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        [StringLength(50, ErrorMessage = "use até {1} caracteres")]
        public string CourseName { get; set; }

        public int CurriculumId { get; set; }

        public Curriculum Curriculum { get; set; }
    }
}
