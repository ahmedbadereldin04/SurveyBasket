using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SurveyBasket.Application.Common.Interfaces;
using SurveyBasket.Application.Contracts.Authentication;
using SurveyBasket.Application.Interfaces;
using SurveyBasket.Domain.Entities;
using SurveyBasket.Infrastructure.Persistence;
using SurveyBasket.Infrastructure.Services;


namespace SurveyBasket.Infrastructure;

public static class DependencyInjention
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        // Database ──────────────────────────────────────────────────────────

        var connectionString = config.GetConnectionString("DefaultConnection") ??
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");


        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));



        // Services ─────────────────────────────────────────────────────────
        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetRequiredService<ApplicationDbContext>());



        // Add Auth Config ─────────────────────────────────────────────────────────
        var jwtSettings = config.GetSection(JwtOptions.SectionName).Get<JwtOptions>();

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
             .AddDefaultTokenProviders();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtProvider, JwtProvider>();

        // Add Options Pattern
        services.AddOptions<JwtOptions>()
            .Bind(config.GetSection(JwtOptions.SectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart();


        // Add JWT Configurations
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
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings?.Key!)),
                ValidIssuer = jwtSettings?.Issuer,
                ValidAudience = jwtSettings?.Audience
            };
        });


        // Add Swagger Configurations ─────────────────────────────────────────────────────────
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "WiseGrader System",
                Version = "v1",
                Description = "WiseGrader Management System",
                Contact = new OpenApiContact
                {
                    Name = "WiseGrader"
                }
            });

            // JWT Authentication ─────────────────────────────────────────────────────────
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter your JWT token"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                    },
                        Array.Empty<string>()
                }
            });


        });


        // CORS ─────────────────────────────────────────────────────────
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .AllowAnyOrigin();    
            });
               
        });

        return services;
    }
}
