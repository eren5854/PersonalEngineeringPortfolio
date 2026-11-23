using ED.GenericRepository;
using PersonalEngineeringPortfolio.Context;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Repositories.SiteProfileRepositories;

public class SiteProfileRepository : Repository<SiteProfile, ApplicationDbContext>, ISiteProfileRepository
{
    public SiteProfileRepository(ApplicationDbContext context) : base(context)
    {
    }
}
