using esluzba.DataAccess.Entities;
using esluzba.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace esluzba.DataAccess.EntityTypeConfig;

public class UserTypeConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.HasMany(c => c.MyServices).WithOne(c => c.User).HasForeignKey(c => c.UserId);
        builder.HasMany(c => c.MyAttendance).WithOne(c => c.User).HasForeignKey(c => c.UserId);
    }
}