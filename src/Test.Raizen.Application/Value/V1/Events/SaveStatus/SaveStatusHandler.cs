using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Test.Raizen.Application.Base;

namespace Test.Raizen.Application.Value.V1.Events.SaveStatus
{
    public class SaveStatusHandler : EventHandlerBase<SaveStatusEvent>
    {

        private readonly ILogger<SaveStatusHandler> logger;

        public SaveStatusHandler(ILogger<SaveStatusHandler> logger)
        {
            this.logger = logger;
        }

        public override async Task Handle(SaveStatusEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Status event received");

            await Task.Run(() => Thread.Sleep(1000), cancellationToken);

            logger.LogInformation("Status event saved");
        }
    }
}
