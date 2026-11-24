namespace PersonalEngineeringPortfolio.DTOs.LoginDtos;

public sealed record LoginResponseDto(
    string Token,
    string? RefreshToken,
    DateTime? RefreshTokenExpires);
