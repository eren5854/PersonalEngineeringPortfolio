using ED.GenericRepository;
using PersonalEngineeringPortfolio.Context;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Repositories.MenuItemRepositories;

public class MenuItemRepository : Repository<MenuItem, ApplicationDbContext>, IMenuItemRepository
{
    public MenuItemRepository(ApplicationDbContext context) : base(context)
    {
    }
}
