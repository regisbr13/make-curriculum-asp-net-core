using MakeCurriculum.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakeCurriculum.Map
{
    public class ResumeMap : IEntityTypeConfiguration<Resume>
    {
        public void Configure(EntityTypeBuilder<Resume> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Description).IsRequired().HasMaxLength(1000);

            builder.HasOne(o => o.Curriculum).WithOne(o => o.Resume).HasForeignKey<Resume>(o => o.CurriculumId);

            builder.ToTable("Resumes");
        }
    }
}
