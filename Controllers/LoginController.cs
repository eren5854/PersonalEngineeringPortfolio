using ED.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalEngineeringPortfolio.DTOs.LoginDtos;
using PersonalEngineeringPortfolio.Extensions;
using PersonalEngineeringPortfolio.Services.AuthServices;

namespace PersonalEngineeringPortfolio.Controllers;

[AllowAnonymous]
public sealed class LoginController(IAuthService authService) : Controller
{
    private const string AdminPanelUrl = "/admin-panel";

    [HttpGet("/login")]
    public IActionResult Index()
    {
        // Zaten giriş yapılmışsa tekrar login ekranı gösterme
        if (User.Identity?.IsAuthenticated == true)
            return Redirect(AdminPanelUrl);

        return View();
    }

    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.EmailOrUserName) || string.IsNullOrWhiteSpace(request.Password))
            return BadRequest(new { message = "E-posta ve şifre alanları zorunludur." });

        Result<LoginResponseDto> result = await authService.LoginAsync(request, cancellationToken);

        if (!result.IsSuccessful || result.Data is null)
        {
            string message = string.Join(" ", result.ErrorMessages ?? []);
            return Unauthorized(new { message = string.IsNullOrWhiteSpace(message) ? "Giriş başarısız." : message });
        }

        // Token JS'e verilmez; XSS'e karşı HttpOnly cookie içinde tutulur
        Response.Cookies.Append(AuthCookie.Name, result.Data.Token, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Lax,
            Path = "/",
            Expires = DateTimeOffset.UtcNow.AddHours(8)
        });

        return Ok(new { redirectUrl = AdminPanelUrl });
    }

    [HttpPost("/logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete(AuthCookie.Name, new CookieOptions { Path = "/" });
        return Ok(new { redirectUrl = "/login" });
    }
}