using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MakeCurriculum.Models
{
    public class Language
    {
        public int Id { get; set; }

        [Display(Name="Nome")]
        [Required(ErrorMessage ="campo obrigatório")]
        [StringLength(15, ErrorMessage ="use até {1} caracteres")]
        [Remote("LanguageExist", "Languages")]
        public string Name { get; set; }

        [Display(Name = "Nível")]
        [Required(ErrorMessage = "campo obrigatório")]
        public string Level { get; set; }

        public int CurriculumId { get; set; }

        public Curriculum Curriculum { get; set; }
    }
}
