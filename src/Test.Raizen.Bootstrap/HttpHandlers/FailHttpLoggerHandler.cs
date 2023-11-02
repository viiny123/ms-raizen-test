using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Test.Raizen.Bootstrap.HttpHandlers;

public class FailHttpLoggerHandler : DelegatingHandler
{
    private readonly ILogger logger;

    public FailHttpLoggerHandler(ILogger<FailHttpLoggerHandler> logger)
    {
        this.logger = logger;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            logger.LogTrace($"Url called: {request.RequestUri}, StatusCode: {response.StatusCode}, ResponseBody: {await response.Content.ReadAsStringAsync(cancellationToken)}");
        }

        return response;
    }
}