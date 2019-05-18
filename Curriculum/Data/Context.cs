using Microsoft.EntityFrameworkCore;
using MakeCurriculum.Models;
using MakeCurriculum.Map;

namespace MakeCurriculum.Data
{
    public class Context : DbContext
    {
        public DbSet<Curriculum> Curriculums { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<CoursesType> CoursesTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Academic> Academics { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<LoginInformation> LoginInformations { get; set; }
        public DbSet<ProfessionalExp> ProfessionalExps { get; set; }
        public DbSet<PersonalData> PersonalDatas { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<ExtraActivity> ExtraActivities { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurriculumMap());
            modelBuilder.ApplyConfiguration(new ProfessionalExpMap());
            modelBuilder.ApplyConfiguration(new LanguageMap());
            modelBuilder.ApplyConfiguration(new AcademicMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ObjectiveMap());
            modelBuilder.ApplyConfiguration(new LoginInformationMap());
            modelBuilder.ApplyConfiguration(new CoursesTypeMap());
            modelBuilder.ApplyConfiguration(new ResumeMap());
            modelBuilder.ApplyConfiguration(new ResumeMap());
            modelBuilder.ApplyConfiguration(new ExtraActivityMap());
        }

    }
}
