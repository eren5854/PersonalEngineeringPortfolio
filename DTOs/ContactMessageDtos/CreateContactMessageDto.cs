namespace PersonalEngineeringPortfolio.DTOs.ContactMessageDtos;

public sealed record CreateContactMessageDto(
    string Name,
    string Email,
    string Message
);
