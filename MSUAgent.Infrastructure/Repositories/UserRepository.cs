using MSUAgent.Application.Interfaces;
using MSUAgent.Domain.Entities;
using MSUAgent.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MSUAgent.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .Include(user => user.Roles)
            .FirstOrDefaultAsync(
                user => user.Id == id,
                cancellationToken);
    }
}