namespace MakeCurriculum.Models.ViewModels
{
    public class FormViewModel
    {
        public Curriculum Curriculum { get; set; }
        public Academic Academic { get; set; }
        public ExtraActivity ExtraActivity { get; set; }
        public Objective Objective { get; set; }
        public Language Language { get; set; }
        public PersonalData PersonalData { get; set; }
        public Resume Resume { get; set; }
        public ProfessionalExp ProfessionalExp { get; set; }
    }
}
