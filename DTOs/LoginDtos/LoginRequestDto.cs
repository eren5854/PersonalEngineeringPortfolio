namespace PersonalEngineeringPortfolio.DTOs.LoginDtos;

public sealed record LoginRequestDto(
    string EmailOrUserName,
    string Password
);
