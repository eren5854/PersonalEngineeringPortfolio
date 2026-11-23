using ED.GenericRepository;
using PersonalEngineeringPortfolio.Context;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Repositories.SkillCategoryRepositories;

public class SkillCategoryRepository : Repository<SkillCategory, ApplicationDbContext>, ISkillCategoryRepository
{
    public SkillCategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}
