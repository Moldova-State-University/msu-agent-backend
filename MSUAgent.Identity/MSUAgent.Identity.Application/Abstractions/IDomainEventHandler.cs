using MSUAgent.Identity.Domain.Abstractions;

namespace MSUAgent.Identity.Application.Abstractions;

public interface IDomainEventHandler<in TEvent> where TEvent : IDomainEvent
{
    Task Handle(TEvent @event, CancellationToken ct);
}

public interface IDomainEventHandler
{
    Type EventType { get; }
    Task Handle(IDomainEvent @event, CancellationToken ct);
}