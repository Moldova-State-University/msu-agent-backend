using MSUAgent.Identity.Domain.Abstractions;

namespace MSUAgent.Identity.Application.Abstractions;

public interface IDomainEventDispatcher
{
    public Task Dispatch(IReadOnlyList<IDomainEvent> events, CancellationToken ct);
}