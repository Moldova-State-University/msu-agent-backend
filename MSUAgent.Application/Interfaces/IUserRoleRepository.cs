using MSUAgent.Domain.Entities;

namespace MSUAgent.Application.Interfaces;

public interface IUserRoleRepository : IRepository<UserRole>
{
    Task<UserRole?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
}