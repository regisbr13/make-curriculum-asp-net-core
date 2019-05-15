using MakeCurriculum.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakeCurriculum.Map
{
    public class CoursesTypeMap : IEntityTypeConfiguration<CoursesType>
    {
        public void Configure(EntityTypeBuilder<CoursesType> builder)
        {
            builder.HasKey(ct => ct.Id);

            builder.Property(ct => ct.Type).IsRequired();
            builder.HasIndex(ct => ct.Type).IsUnique();

            builder.HasMany(ct => ct.Academics).WithOne(ct => ct.CoursesType).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
