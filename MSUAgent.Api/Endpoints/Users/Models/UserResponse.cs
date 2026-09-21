namespace MSUAgent.Api.Endpoints.Users.Models;

public record UserResponse(
    Guid Id,
    string DisplayName,
    string Email,
    IReadOnlyCollection<string> Roles);