using BowlingConcept.Domain.Repositories;
using BowlingConcept.Domain.Services;
using BowlingConcept.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BowlingConcept.Application.Dependency;

public static class Registration
{
    public static IServiceCollection AddBowlingConceptModule(this IServiceCollection services)
    {
        services.AddSingleton<IBowlingLaneRepository, BowlingLaneRepository>(_ => new BowlingLaneRepository(4));
        services.AddSingleton<IBowlingGameRepository, BowlingGameRepository>();
        services.AddScoped<BowlingScoreCalculator>();

        services.AddScoped<GetBowlingLanesHandler>();
        services.AddScoped<StartNewGameHandler>();
        services.AddScoped<GetScoreboardHandler>();
        services.AddScoped<BowlingPinsToppledHandler>();

        return services;
    }
}
