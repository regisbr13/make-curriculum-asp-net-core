using MakeCurriculum.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakeCurriculum.Map
{
    public class ExtraActivityMap : IEntityTypeConfiguration<ExtraActivity>
    {
        public void Configure(EntityTypeBuilder<ExtraActivity> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.CourseName).IsRequired(false).HasMaxLength(50);

            builder.Property(a => a.Info).IsRequired().HasMaxLength(300);

            builder.HasOne(a => a.Curriculum).WithMany(a => a.ExtraActivities).HasForeignKey(a => a.CurriculumId);

            builder.ToTable("ExtraActivities");
        }
    }
}
