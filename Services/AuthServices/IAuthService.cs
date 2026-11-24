using ED.Result;
using PersonalEngineeringPortfolio.DTOs.LoginDtos;

namespace PersonalEngineeringPortfolio.Services.AuthServices;

public interface IAuthService
{
    Task<Result<LoginResponseDto>> LoginAsync(LoginRequestDto request, CancellationToken cancellationToken);
}
