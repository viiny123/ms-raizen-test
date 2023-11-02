using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Test.Raizen.Application.Base
{
    public abstract class EventHandlerBase<TNotification> : INotificationHandler<TNotification>
        where TNotification : EventBase
    {
        public abstract Task Handle(TNotification notification, CancellationToken cancellationToken);
    }
}
