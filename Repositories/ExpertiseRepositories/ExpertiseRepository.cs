using ED.GenericRepository;
using PersonalEngineeringPortfolio.Context;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Repositories.ExpertiseRepositories;

public class ExpertiseRepository : Repository<Expertise, ApplicationDbContext>, IExpertiseRepository
{
    public ExpertiseRepository(ApplicationDbContext context) : base(context)
    {
    }
}
