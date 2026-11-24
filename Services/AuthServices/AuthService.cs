using ED.Result;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PersonalEngineeringPortfolio.DTOs.LoginDtos;
using PersonalEngineeringPortfolio.Models;
using PersonalEngineeringPortfolio.Services.JwtServices;

namespace PersonalEngineeringPortfolio.Services.AuthServices;

public sealed class AuthService(
    UserManager<AppUser> userManager,
    SignInManager<AppUser> signInManager,
    IJwtProvider jwtProvider) : IAuthService
{
    public async Task<Result<LoginResponseDto>> LoginAsync(LoginRequestDto request, CancellationToken cancellationToken)
    {
        string emailOrUsername = request.EmailOrUserName;
        AppUser? appUser = await userManager
            .Users
            .FirstOrDefaultAsync(p => p.Email == emailOrUsername ||
                                    p.UserName == emailOrUsername, cancellationToken);
        if (appUser is null)
            return Result<LoginResponseDto>.Failure("Kullanıcı bulunamadı");

        SignInResult signInResult = await signInManager.CheckPasswordSignInAsync(appUser, request.Password, true);
        if (signInResult.IsLockedOut)
        {
            TimeSpan? timeSpan = appUser.LockoutEnd - DateTimeOffset.UtcNow;
            if (timeSpan is not null)
                return Result<LoginResponseDto>.Failure($"Şifre 5 defa hatalı girildi! Lütfen {Math.Ceiling(timeSpan.Value.TotalSeconds)} saniye bekleyiniz.");
            else
                return Result<LoginResponseDto>.Failure("Wait 3 minutes");
        }
        if (!signInResult.Succeeded)
        {
            return Result<LoginResponseDto>.Failure("Şifre Yanlış");
        }

        var loginResponse = await jwtProvider.CreateToken(appUser);
        await userManager.UpdateAsync(appUser);
        return loginResponse;
    }
}
