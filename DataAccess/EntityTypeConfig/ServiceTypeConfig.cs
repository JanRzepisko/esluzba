using esluzba.DataAccess.Entities;
using esluzba.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace esluzba.DataAccess.EntityTypeConfig;

public class ServiceTypeConfig : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.ToTable("Services");
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.HasMany(c => c.Users).WithOne(c => c.Service).HasForeignKey(c => c.ServiceId);
    }
}