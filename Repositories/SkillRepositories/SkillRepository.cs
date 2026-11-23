using ED.GenericRepository;
using PersonalEngineeringPortfolio.Context;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Repositories.SkillRepositories;

public class SkillRepository : Repository<Skill, ApplicationDbContext>, ISkillRepository
{
    public SkillRepository(ApplicationDbContext context) : base(context)
    {
    }
}
