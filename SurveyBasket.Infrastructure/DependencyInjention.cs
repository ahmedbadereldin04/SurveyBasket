using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SurveyBasket.Application.Common.Interfaces;
using SurveyBasket.Application.Interfaces;
using SurveyBasket.Domain.Entities;
using SurveyBasket.Infrastructure.Persistence;
using SurveyBasket.Infrastructure.Services;
namespace SurveyBasket.Infrastructure;

public static class DependencyInjention
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        // ── Database ──────────────────────────────────────────────────────────

        var connectionString = config.GetConnectionString("DefaultConnection") ??
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");


        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));


        // ── Services ─────────────────────────────────────────────────────────
        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetRequiredService<ApplicationDbContext>());
        


        // Add Auth Config ─────────────────────────────────────────────────────────
        services.AddIdentity<ApplicationUser,IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
             .AddDefaultTokenProviders();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtProvider, JwtProvider>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(o =>
        {
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("J7MfAb4WcAIMkkigVtleplILOVJEjAcB")),
                ValidIssuer = "SurveyBasketApp",
                ValidAudience = "SurveyBasketAppUsers"
            };
        });

        

        return services;
    }
}
