using Microsoft.OpenApi.Models;

namespace SurveyBasket.Api.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services, IConfiguration config)
    {
        // Add Controllers Configurations ─────────────────────────────────────────────────────
        services.AddControllers();
        services.AddEndpointsApiExplorer();


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


        // Exception Handler ─────────────────────────────────────────────────────────
        services.AddExceptionHandler<GlobalExecptionHandler>();
        services.AddProblemDetails();

        return services;
    }

}
