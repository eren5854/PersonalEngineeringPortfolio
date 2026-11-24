using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Configurations;

public sealed class ContactMessageConfiguration : IEntityTypeConfiguration<ContactMessage>
{
    public void Configure(EntityTypeBuilder<ContactMessage> builder)
    {
        builder.ToTable("ContactMessages");

        builder.HasQueryFilter(filter => !filter.IsDeleted);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Email).IsRequired().HasMaxLength(150);
        builder.Property(p => p.Message).IsRequired().HasMaxLength(2000);
        builder.Property(p => p.IsRead).IsRequired();

        // Admin panelde "okunmamış mesajlar" listesi için
        builder.HasIndex(p => p.IsRead);
    }
}
