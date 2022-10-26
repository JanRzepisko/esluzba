using esluzba.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace esluzba.DataAccess.EntityTypeConfig;

public class UserServiceRelationTypeConfig : IEntityTypeConfiguration<UserServicesRelation>
{
    public void Configure(EntityTypeBuilder<UserServicesRelation> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.HasOne(c => c.Service).WithMany(c => c.Users).HasForeignKey(c => c.ServiceId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(c => c.User).WithMany(c => c.MyServices).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Cascade);
    }
}