using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using SurveyBasket.Application.Contracts.Polls;
using SurveyBasket.Application.Interfaces;
using SurveyBasket.Application.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SurveyBasket.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IPollService, PollService>();



        //Add Mapster ──────────────────────────────────────────────────────────
        var mappingconfig = TypeAdapterConfig.GlobalSettings;
        mappingconfig.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMapper>(new Mapper(mappingconfig));




        // Add Validation ──────────────────────────────────────────────────────────
        services
            .AddFluentValidationAutoValidation()
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
