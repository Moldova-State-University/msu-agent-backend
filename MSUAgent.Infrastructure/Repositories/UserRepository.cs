using MSUAgent.Application.Interfaces;
using MSUAgent.Domain.Entities;
using MSUAgent.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MSUAgent.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users
            .Include(user => user.Roles)
            .FirstOrDefaultAsync(
                user => user.Id == id,
                cancellationToken);
    }
}