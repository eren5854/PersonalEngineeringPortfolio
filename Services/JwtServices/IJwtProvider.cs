using PersonalEngineeringPortfolio.DTOs.LoginDtos;
using PersonalEngineeringPortfolio.Models;

namespace PersonalEngineeringPortfolio.Services.JwtServices;

public interface IJwtProvider
{
    Task<LoginResponseDto> CreateToken(AppUser user);
}
