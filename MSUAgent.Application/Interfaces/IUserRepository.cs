using MSUAgent.Domain.Entities;

namespace MSUAgent.Application.Interfaces;
public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}