using MSUAgent.Domain.Entities;

namespace MSUAgent.Application.Interfaces;

public interface IUserRoleRepository : IRepository<UserRole>
{
    Task<UserRole?> GetByUserIdAsync(string name, CancellationToken cancellationToken = default);
    Task<UserRole?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
}