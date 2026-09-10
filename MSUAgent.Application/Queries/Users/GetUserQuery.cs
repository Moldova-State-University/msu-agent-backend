using MediatR;

public record GetUserQuery(Guid Id) : IRequest<UserResponse?>;

public record UserResponse(
    Guid Id,
    string DisplayName,
    string Email,
    IReadOnlyCollection<string> Roles);