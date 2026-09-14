namespace MSUAgent.Application.Queries.Users
{
    public record UserDto(
    Guid Id,
    string DisplayName,
    string Email,
    IReadOnlyCollection<string> Roles);
}
