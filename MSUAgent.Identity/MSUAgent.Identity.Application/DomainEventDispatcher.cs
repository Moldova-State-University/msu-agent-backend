using MSUAgent.Identity.Application.Abstractions;
using MSUAgent.Identity.Domain.Abstractions;

namespace MSUAgent.Identity.Application;

public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IEnumerable<IDomainEventHandler> _handlers;

    public DomainEventDispatcher(IEnumerable<IDomainEventHandler> handlers)
        => _handlers = handlers;

    public async Task Dispatch(IReadOnlyList<IDomainEvent> events, CancellationToken ct)
    {
        foreach (var @event in events)
        {
            var eventType = @event.GetType();

            foreach (var handler in _handlers)
            {
                if (handler.EventType == eventType)
                    await handler.Handle(@event, ct);
            }
        }
    }
}