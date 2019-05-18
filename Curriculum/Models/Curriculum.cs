using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Models
{
    public class Curriculum
    {
        public int Id { get; set; }

        [Display(Name ="Nome do currículo")]
        [Required(ErrorMessage ="campo obrigatório")]
        [StringLength(50, ErrorMessage ="use até {1} caracteres")]
        public string Name { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public PersonalData PersonalData { get; set; }

        public ICollection<Objective> Objectives { get; set; }

        public ICollection<Academic> Academics { get; set; }

        public ICollection<ProfessionalExp> ProfessionalExps { get; set; }

        public ICollection<Language> Languages { get; set; }

        public ICollection<ExtraActivity> ExtraActivities { get; set; }

        public Resume Resume { get; set; }
    }
}
