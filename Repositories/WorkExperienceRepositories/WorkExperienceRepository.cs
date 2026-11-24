using ED.GenericRepository;
using PersonalEngineeringPortfolio.Context;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Repositories.WorkExperienceRepositories;

public class WorkExperienceRepository : Repository<WorkExperience, ApplicationDbContext>, IWorkExperienceRepository
{
    public WorkExperienceRepository(ApplicationDbContext context) : base(context)
    {
    }
}
