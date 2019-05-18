using MakeCurriculum.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakeCurriculum.Map
{
    public class PersonalDataMap : IEntityTypeConfiguration<PersonalData>
    {
        public void Configure(EntityTypeBuilder<PersonalData> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);

            builder.Property(a => a.Nationality).IsRequired(false).HasMaxLength(20);

            builder.Property(a => a.Adress).IsRequired(false).HasMaxLength(100);

            builder.Property(a => a.Age).IsRequired();

            builder.Property(a => a.CivilStatus).IsRequired(false).HasMaxLength(15);

            builder.Property(a => a.Email).IsRequired(false).HasMaxLength(50);

            builder.Property(a => a.Site).IsRequired(false).HasMaxLength(50);

            builder.Property(a => a.Phone).IsRequired(false).HasMaxLength(50);

            builder.HasOne(a => a.Curriculum).WithOne(a => a.PersonalData).HasForeignKey<PersonalData>(a => a.CurriculumId);

            builder.ToTable("PersonalData");
        }
    }
}
