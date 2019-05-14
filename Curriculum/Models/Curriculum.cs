using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Models
{
    public class Curriculum
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Objective> Objectives { get; set; }

        public ICollection<Academic> Academics { get; set; }

        public ICollection<ProfessionalExp> ProfessionalExps { get; set; }

        public ICollection<Language> Languages { get; set; }
    }
}
