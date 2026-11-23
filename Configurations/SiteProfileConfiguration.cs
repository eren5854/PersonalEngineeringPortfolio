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
    }
}
