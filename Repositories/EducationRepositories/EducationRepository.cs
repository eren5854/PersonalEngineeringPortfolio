using ED.GenericRepository;
using PersonalEngineeringPortfolio.Context;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Repositories.EducationRepositories;

public class EducationRepository : Repository<Education, ApplicationDbContext>, IEducationRepository
{
    public EducationRepository(ApplicationDbContext context) : base(context)
    {
    }
}
