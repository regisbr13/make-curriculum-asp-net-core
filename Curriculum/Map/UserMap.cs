using MakeCurriculum.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakeCurriculum.Map
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email).IsRequired().HasMaxLength(50);
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Password).IsRequired().HasMaxLength(50);

            builder.HasMany(u => u.Curriculums).WithOne(u => u.User).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(u => u.LoginInformations).WithOne(u => u.User).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Users");
        }
    }
}
