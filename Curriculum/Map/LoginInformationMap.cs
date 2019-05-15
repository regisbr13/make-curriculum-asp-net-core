using MakeCurriculum.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakeCurriculum.Map
{
    public class LoginInformationMap : IEntityTypeConfiguration<LoginInformation>
    {
        public void Configure(EntityTypeBuilder<LoginInformation> builder)
        {
            builder.HasKey(li => li.Id);

            builder.Property(li => li.Ip).IsRequired();
            builder.Property(li => li.LoginDate).IsRequired();

            builder.HasOne(li => li.User).WithMany(li => li.LoginInformations).HasForeignKey(li => li.UserId);

            builder.ToTable("LoginInformations");
        }
    }
}
