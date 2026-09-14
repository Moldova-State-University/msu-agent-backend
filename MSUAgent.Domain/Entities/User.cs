namespace MSUAgent.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string DisplayName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public List<UserRole> Roles { get; set; } = [];
}