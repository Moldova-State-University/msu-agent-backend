using MSUAgent.Application.Interfaces;
using MSUAgent.Domain.Entities;
using MSUAgent.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MSUAgent.Infrastructure.Repositories;

public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<UserRole?> GetByUserIdAsync(string name, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<UserRole>()
            .FirstOrDefaultAsync(
                role => role.Name == name,
                cancellationToken);
    }

    public async Task<UserRole?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<UserRole>()
            .FirstOrDefaultAsync(
                role => role.Name == name,
                cancellationToken);
    }
}