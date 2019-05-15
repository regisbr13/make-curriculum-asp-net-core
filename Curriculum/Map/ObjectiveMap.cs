using MakeCurriculum.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakeCurriculum.Map
{
    public class ObjectiveMap : IEntityTypeConfiguration<Objective>
    {
        public void Configure(EntityTypeBuilder<Objective> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Description).IsRequired().HasMaxLength(1000);

            builder.HasOne(o => o.Curriculum).WithMany(o => o.Objectives).HasForeignKey(o => o.CurriculumId);

            builder.ToTable("Objectives");
        }
    }
}
