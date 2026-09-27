using MSUAgent.Identity.Domain.Abstractions;

namespace MSUAgent.Identity.Application.Abstractions;

public abstract class DomainEventHandler<TEvent> : IDomainEventHandler<TEvent>, IDomainEventHandler
    where TEvent : IDomainEvent
{
    public Type EventType => typeof(TEvent);

    public abstract Task Handle(TEvent @event, CancellationToken ct);

    public Task Handle(IDomainEvent @event, CancellationToken ct) => Handle((TEvent)@event, ct);  
}