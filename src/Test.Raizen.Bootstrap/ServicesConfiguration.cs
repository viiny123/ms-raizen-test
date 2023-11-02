using System.Diagnostics.CodeAnalysis;
using Test.Raizen.Bootstrap.Providers;
using Elastic.Apm.NetCoreAll;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Test.Raizen.Bootstrap;

[ExcludeFromCodeCoverage]
public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.ConfigureMvcServices();
        services.ConfigureHealthCheck(configuration);
        services.ConfigureMediatr();
        services.ConfigureDatabases(configuration);
        services.ConfigureTestModule(configuration);

        return services;
    }

    public static IApplicationBuilder Configure(this IApplicationBuilder app, IConfiguration configuration)
    {
        app.ConfigureMiddlewares();
        app.ConfigureMvc();
        app.ConfigureHealthCheck();
        app.UseAuthorization();
        app.RunMigrations();

        return app;
    }
}

