using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Refit;
using Test.Raizen.Application.Services.ViaCep.API;
using Test.Raizen.Bootstrap.HttpHandlers;
using Test.Raizen.Bootstrap.Providers.Options;

namespace Test.Raizen.Bootstrap.Providers;

public static class HttpClientConfiguration
{
    public static IServiceCollection ConfigureHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRefitClient<IViaCepApi>(RefitSettingsOption.DefaultSettings())
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(configuration.GetValue<string>("ViaCepApi:BaseAddress"));
                })
                .AddHttpMessageHandler<FailHttpLoggerHandler>()
                .AddHttpMessageHandler(provider =>
                    new RetryHttpHandler(
                        provider.GetRequiredService<ILoggerFactory>(),
                        configuration.GetValue<int>("ViaCepApi:Resilience:RetryCount"),
                        configuration.GetValue<int>("ViaCepApi:Resilience:Timeout")));

        return services;
    }
}
