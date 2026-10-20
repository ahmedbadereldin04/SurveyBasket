using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SurveyBasket.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

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




        return services;
    }
}
