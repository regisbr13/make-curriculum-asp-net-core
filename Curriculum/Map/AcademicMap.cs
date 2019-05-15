using MakeCurriculum.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Map
{
    public class AcademicMap : IEntityTypeConfiguration<Academic>
    {
        public void Configure(EntityTypeBuilder<Academic> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Institution).IsRequired().HasMaxLength(50);

            builder.Property(a => a.StartYear).IsRequired();

            builder.Property(a => a.EndYear).IsRequired();

            builder.Property(a => a.CourseName).IsRequired().HasMaxLength(50);

            builder.HasOne(a => a.CoursesType).WithMany(a => a.Academics).HasForeignKey(a => a.CoursesTypeId);

            builder.HasOne(a => a.Curriculum).WithMany(a => a.Academics).HasForeignKey(a => a.CurriculumId);

            builder.ToTable("Academics");
        }
    }
}
