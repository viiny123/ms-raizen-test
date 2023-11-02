using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using Polly.Timeout;

namespace Test.Raizen.Bootstrap.Providers;

[ExcludeFromCodeCoverage]
public static class ResilienceApiClientConfiguration
{
    public static AsyncRetryPolicy<HttpResponseMessage> PolicyRetryConfig(IServiceCollection services,
        int retryCount = 3)
    {
        var serviceProvider = services.BuildServiceProvider();
        var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
        var retryLogger = loggerFactory.CreateLogger("PollyHttpRetryPoliciesLogger");

        return HttpPolicyExtensions
               .HandleTransientHttpError()
               .OrTransientHttpError()
               .OrResult(msg => msg.StatusCode == HttpStatusCode.InternalServerError)
               .OrResult(msg => msg.StatusCode == HttpStatusCode.GatewayTimeout)
               .OrResult(msg => msg.StatusCode == HttpStatusCode.BadGateway)
               .OrResult(msg => msg.StatusCode == HttpStatusCode.ServiceUnavailable)
               .Or<TimeoutRejectedException>()
               .WaitAndRetryAsync(retryCount,
                   retryAttempt => TimeSpan.FromSeconds(Math.Pow(retryAttempt, 2)),
                   onRetry: (response, delay, retryCount, context) =>
                   {
                       using var act = Activity.Current;
                       if (response.Exception != null)
                       {
                           act.SetTag("exception.message", response.Exception.Message);
                           act.SetTag("exception.stack_trace", response.Exception.StackTrace);

                           retryLogger.LogError(response.Exception, $"Provider Error. Error Response Message: {response.Exception.Message}");
                           retryLogger.LogInformation("Sending again after Delay: {delay} - Attemp Number: {retryCount}", delay, retryCount);
                       }

                       retryLogger.LogInformation("Sending again after Delay: {delay} - Attemp Number: {retryCount}", delay, retryCount);
                   });
    }

    public static AsyncTimeoutPolicy<HttpResponseMessage> PolicyTimeout(int timeOutException = 15)
    {
        return Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(timeOutException));
    }
}