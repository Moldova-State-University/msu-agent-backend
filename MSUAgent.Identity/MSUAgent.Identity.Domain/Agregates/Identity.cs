using MSUAgent.Identity.Domain.Abstractions;
using MSUAgent.Identity.Domain.Enums;
using MSUAgent.Identity.Domain.Events;

namespace MSUAgent.Identity.Domain.Agregates;

public class Identity : AggregateRoot
{
    public string IdentityId { get; set; } = null!;

    public IdentityProvider IdentityProvider { get; init; }

    public DateTime CreatedAt { get; init; }

    public DateTime UpdatedAt { get; set; }

    public Guid User { get; init; }

    private Identity()
    {
        RaiseEvent(new IdentityCreated());
        RaiseEvent(new SampleEvent());
    }

    public static Identity Create()
    {
        return new Identity();
    }
}