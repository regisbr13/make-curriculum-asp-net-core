using MakeCurriculum.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakeCurriculum.Map
{
    public class LanguageMap : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(l => l.Name).IsUnique();

            builder.Property(l => l.Level).IsRequired().HasMaxLength(50);

            builder.HasOne(l => l.Curriculum).WithMany(l => l.Languages).HasForeignKey(l => l.CurriculumId);

            builder.ToTable("Languages");
        }
    }
}
