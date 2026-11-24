using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Configurations;

public sealed class SocialLinkConfiguration : IEntityTypeConfiguration<SocialLink>
{
    public void Configure(EntityTypeBuilder<SocialLink> builder)
    {
        builder.ToTable("SocialLinks");

        builder.HasQueryFilter(filter => !filter.IsDeleted);

        // Enum veritabanında okunabilir metin olarak tutulur (LinkedIn, GitHub...)
        builder.Property(p => p.Platform)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(p => p.Url).IsRequired().HasMaxLength(300);
        builder.Property(p => p.ShowInHero).IsRequired();
        builder.Property(p => p.ShowInFooter).IsRequired();

        builder.HasIndex(p => p.DisplayOrder);
    }
}
