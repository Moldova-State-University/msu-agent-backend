using MSUAgent.Application.Interfaces;

namespace MSUAgent.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;

    public UnitOfWork(AppDbContext dbContext, IUserRepository userRepository)
    {
        _dbContext = dbContext;
        Users = userRepository;
    }

    public IUserRepository Users { get; }

    public async Task SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}