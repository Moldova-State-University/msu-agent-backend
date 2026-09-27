using MSUAgent.Identity.Domain.Abstractions;

namespace MSUAgent.Identity.Domain.Agregates;

public class User : AggregateRoot
{
    List<Guid> Identities { get; init; } = [];
}