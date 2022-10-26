using esluzba.DataAccess.Entities;
using esluzba.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace esluzba.DataAccess.EntityTypeConfig;

public class ParishTypeConfig : IEntityTypeConfiguration<Parish>
{
    public void Configure(EntityTypeBuilder<Parish> builder)
    {
        builder.ToTable("Prishes");
        builder.HasKey(c => c.Id);
        builder.HasIndex(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();

        builder.Property(c => c.Name).IsRequired();
        builder.HasMany(c => c.Users).WithOne(c => c.Parish).HasForeignKey(c => c.ParishId);
    }
}
