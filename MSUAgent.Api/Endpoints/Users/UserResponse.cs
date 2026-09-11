namespace MSUAgent.Api.Endpoints.Users;

public record UserResponse(
    Guid Id,
    string DisplayName,
    string Email,
    IReadOnlyCollection<string> Roles);