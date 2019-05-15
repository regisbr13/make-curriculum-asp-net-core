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
        }
    }
}
