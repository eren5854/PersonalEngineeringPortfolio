using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Configurations;

public sealed class SiteProfileConfiguration : IEntityTypeConfiguration<SiteProfile>
{
    public void Configure(EntityTypeBuilder<SiteProfile> builder)
    {
        builder.ToTable("SiteProfiles");

        builder.HasQueryFilter(filter => !filter.IsDeleted);

        builder.Property(p => p.SiteTitle).IsRequired().HasMaxLength(150);
        builder.Property(p => p.LogoText).IsRequired().HasMaxLength(3);
        builder.Property(p => p.LogoImagePath).HasMaxLength(300);
        builder.Property(p => p.FullName).IsRequired().HasMaxLength(100);
        builder.Property(p => p.AboutText).IsRequired().HasMaxLength(1500);
        builder.Property(p => p.PhotoPath).HasMaxLength(300);
        builder.Property(p => p.Email).IsRequired().HasMaxLength(150);
        builder.Property(p => p.Phone).IsRequired().HasMaxLength(30);
        builder.Property(p => p.Address).HasMaxLength(200);
        builder.Property(p => p.FooterDescription).HasMaxLength(300);
        builder.Property(p => p.FooterSlogan).HasMaxLength(150);
    }
}
