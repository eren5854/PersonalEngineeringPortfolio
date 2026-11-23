using ED.GenericRepository;
using PersonalEngineeringPortfolio.Context;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Repositories.ProjectRepositories;

public class ProjectRepository : Repository<Project, ApplicationDbContext>, IProjectRepository
{
    public ProjectRepository(ApplicationDbContext context) : base(context)
    {
    }
}
