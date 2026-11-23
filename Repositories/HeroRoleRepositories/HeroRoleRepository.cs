using ED.GenericRepository;
using PersonalEngineeringPortfolio.Context;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Repositories.HeroRoleRepositories;

public class HeroRoleRepository : Repository<HeroRole, ApplicationDbContext>, IHeroRoleRepository
{
    public HeroRoleRepository(ApplicationDbContext context) : base(context)
    {
    }
}
