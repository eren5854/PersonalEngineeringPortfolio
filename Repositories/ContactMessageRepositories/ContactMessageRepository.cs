using ED.GenericRepository;
using PersonalEngineeringPortfolio.Context;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Repositories.ContactMessageRepositories;

public class ContactMessageRepository : Repository<ContactMessage, ApplicationDbContext>, IContactMessageRepository
{
    public ContactMessageRepository(ApplicationDbContext context) : base(context)
    {
    }
}
