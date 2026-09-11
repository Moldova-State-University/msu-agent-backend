using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MSUAgent.Infrastructure.Persistence
{
    internal class DataSeederHelper
    {
        public static async Task SeedIfEmptyAsync<T>(
            DbSet<T> dbSet,
            Func<CancellationToken, Task> seedAction,
            ILogger logger,
            CancellationToken cancellationToken) where T : class
        {
            if (!await dbSet.AnyAsync(cancellationToken))
            {
                var entityName = typeof(T).Name;

                logger.LogInformation($"Seeding {entityName}...");

                await seedAction(cancellationToken);

                logger.LogInformation($"Seeding {entityName} finished.");
            }
        }
    }
}