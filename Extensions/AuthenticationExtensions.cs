using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PersonalEngineeringPortfolio.Options;
using System.Text;

namespace PersonalEngineeringPortfolio.Extensions;

/// <summary>JWT'nin tutulduğu HttpOnly cookie adı.</summary>
public static class AuthCookie
{
    public const string Name = "portfolio_auth";
}

public static class AuthenticationExtensions
{
    /// <summary>
    /// JWT doğrulamasını kurar. Token tarayıcıda HttpOnly cookie olarak durur;
    /// her istekte cookie'den okunup doğrulanır. Böylece /admin-panel gibi
    /// sayfa gezintilerinde de [Authorize] çalışır.
    /// </summary>
    public static IServiceCollection AddJwtCookieAuthentication(this IServiceCollection services)
    {
        // AddIdentity varsayılan şemayı cookie yapar; burada açıkça JWT'ye çeviriyoruz.
        // Böylece AddIdentity'den önce veya sonra çağrılsa da [Authorize] JWT ile çalışır.
        services
            .AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer();

        // JwtOption'ı kendi kayıt ettiğin IOptions<JwtOption> üzerinden okur.
        services
            .AddOptions<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme)
            .Configure<IOptions<JwtOption>>((options, jwtOption) =>
            {
                var jwt = jwtOption.Value;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwt.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwt.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SecretKey)),
                    ValidAlgorithms = [SecurityAlgorithms.HmacSha512],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    NameClaimType = "UserName"
                };

                options.Events = new JwtBearerEvents
                {
                    // Authorization header yoksa token'ı cookie'den al
                    OnMessageReceived = context =>
                    {
                        if (string.IsNullOrEmpty(context.Token) &&
                            context.Request.Cookies.TryGetValue(AuthCookie.Name, out var token))
                        {
                            context.Token = token;
                        }
                        return Task.CompletedTask;
                    },

                    // Yetkisiz sayfa isteğinde 401 yerine login sayfasına yönlendir
                    OnChallenge = context =>
                    {
                        if (!context.Request.Path.StartsWithSegments("/api"))
                        {
                            context.HandleResponse();
                            context.Response.Redirect("/login");
                        }
                        return Task.CompletedTask;
                    }
                };
            });

        services.AddAuthorization();

        return services;
    }
}
