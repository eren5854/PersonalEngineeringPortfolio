using ED.GenericRepository;
using PersonalEngineeringPortfolio.Context;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Repositories.SocialLinkRepositories;

public class SocialLinkrepository : Repository<SocialLink, ApplicationDbContext>, ISocialLinkRepository
{
    public SocialLinkrepository(ApplicationDbContext context) : base(context)
    {
    }
}
