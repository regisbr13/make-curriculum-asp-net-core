using MakeCurriculum.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Map
{
    public class ProfessionalExpMap : IEntityTypeConfiguration<ProfessionalExp>
    {
        public void Configure(EntityTypeBuilder<ProfessionalExp> builder)
        {
            builder.HasKey(pe => pe.Id);

            builder.Property(pe => pe.Company).IsRequired().HasMaxLength(50);

            builder.Property(pe => pe.Role).IsRequired().HasMaxLength(50);

            builder.Property(pe => pe.Activities).IsRequired().HasMaxLength(500);

            builder.Property(pe => pe.StartYear).IsRequired();

            builder.Property(pe => pe.EndYear).IsRequired();

            builder.HasOne(pe => pe.Curriculum).WithMany(pe => pe.ProfessionalExps).HasForeignKey(pe => pe.CurriculumId);

            builder.ToTable("ProfessionalExps");
        }
    }
}
