using System.ComponentModel.DataAnnotations;

namespace MakeCurriculum.Models
{
    public class Language
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="campo obrigatório")]
        [StringLength(15, ErrorMessage ="use até {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        public string Level { get; set; }

        public int CurriculumId { get; set; }

        public Curriculum Curriculum { get; set; }
    }
}
