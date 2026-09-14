using Microsoft.EntityFrameworkCore;
using MSUAgent.Application.Interfaces;
using MSUAgent.Infrastructure.Persistence;

namespace MSUAgent.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>()
                .FirstOrDefaultAsync(
                entity => EF.Property<Guid>(entity, "Id") == id,
                cancellationToken
               );
        }
    }
}
