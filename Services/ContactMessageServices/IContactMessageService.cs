using ED.Result;
using PersonalEngineeringPortfolio.DTOs.ContactMessageDtos;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Services.ContactMessageServices;

public interface IContactMessageService
{
    Task<Result<string>> Create(CreateContactMessageDto request, CancellationToken cancellationToken);
    Task<Result<IQueryable<ContactMessage>>> GetAll(CancellationToken cancellationToken);
    Task<Result<ContactMessage>> GetById(Guid id, CancellationToken cancellationToken);
    Task<Result<string>> Delete(Guid id, CancellationToken cancellationToken);
}
