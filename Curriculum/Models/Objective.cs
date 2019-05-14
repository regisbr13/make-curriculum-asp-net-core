using System.ComponentModel.DataAnnotations;

namespace MakeCurriculum.Models
{
    public class Objective
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="descrição obrigatória")]
        [StringLength(1000, ErrorMessage ="use até {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public int CurriculumId { get; set; }

        public Curriculum Curriculum { get; set; }
    }
}
