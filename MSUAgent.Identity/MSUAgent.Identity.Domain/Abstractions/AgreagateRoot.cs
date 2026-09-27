namespace MSUAgent.Identity.Domain.Abstractions;

public abstract class AggregateRoot : IEntity
{
    public Guid Id { get; set; }

    private readonly List<IDomainEvent> _domainEvents = [];

    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

    protected void RaiseEvent(IDomainEvent @event) => _domainEvents.Add(@event);

    public void ClearDomainEvents() => _domainEvents.Clear();
}