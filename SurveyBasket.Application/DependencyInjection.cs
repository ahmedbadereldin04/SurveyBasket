namespace SurveyBasket.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddControllers();


        services.AddScoped<IPollService, PollService>();
        services.AddScoped<IQuestionService, QuestionService>();
        

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
