using System.Diagnostics.CodeAnalysis;
using Test.Raizen.Data.Base;
using Test.Raizen.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test.Raizen.Bootstrap.HttpHandlers;
using Test.Raizen.Domain.AggregatesModel.ValueAggreate;
using Test.Raizen.Domain.Base;

namespace Test.Raizen.Bootstrap.Providers;

[ExcludeFromCodeCoverage]
public static class TestConfiguration
{
    public static IServiceCollection ConfigureTestModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddTransient<FailHttpLoggerHandler>();

        return services;
    }
}
