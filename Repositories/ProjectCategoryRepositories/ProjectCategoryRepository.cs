using ED.GenericRepository;
using PersonalEngineeringPortfolio.Context;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Repositories.ProjectCategoryRepositories;

public class ProjectCategoryRepository : Repository<ProjectCategory, ApplicationDbContext>, IProjectCategoryRepository
{
    public ProjectCategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}
