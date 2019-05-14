using System.Collections.Generic;

namespace MakeCurriculum.Models
{
    public class CoursesType
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public ICollection<Academic> Academics { get; set; }
    }
}
