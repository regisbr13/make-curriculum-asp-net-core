using MakeCurriculum.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Map
{
    public class CurriculumMap : IEntityTypeConfiguration<Curriculum>
    {
        public void Configure(EntityTypeBuilder<Curriculum> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);

            builder.HasOne(c => c.User).WithMany(c => c.Curriculums).HasForeignKey(c => c.UserId);

            builder.HasMany(c => c.Objectives).WithOne(c => c.Curriculum).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Academics).WithOne(c => c.Curriculum).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.ProfessionalExps).WithOne(c => c.Curriculum).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Languages).WithOne(c => c.Curriculum).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.PersonalData).WithOne(c => c.Curriculum).OnDelete(DeleteBehavior.Cascade);


            builder.ToTable("Curriculums");
        }
    }
}
