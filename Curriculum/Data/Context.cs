using Microsoft.EntityFrameworkCore;
using MakeCurriculum.Models;

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
    }
}
