using Microsoft.Extensions.Logging;
using MSUAgent.Domain.Entities;

namespace MSUAgent.Infrastructure.Persistence;

public class DataSeeder(AppDbContext dbContext, ILogger<AppDbContext> logger) : IDataSeeder
{
    public async Task SeedAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Seeding the database...");

        await DataSeederHelper.SeedIfEmptyAsync(dbContext.Users, SeedAdvertisementsAsync, logger, cancellationToken);

        logger.LogInformation("Seeding the database finished.");
    }

    private async Task SeedAdvertisementsAsync(CancellationToken cancellationToken)
    {
        var roles = new UserRole[]
        {
            new() { Id = Guid.NewGuid(), Name = "Member" },
            new() { Id = Guid.NewGuid(), Name = "Admin" },
            new() { Id = Guid.NewGuid(), Name = "Owner" },
        };

        var users = new User[]
        {
            new() { Id = Guid.NewGuid(), DisplayName = "John Weeeek", Email = "johnweeeek@continental.com", Roles = [roles[0], roles[1]] },
            new() { Id = Guid.NewGuid(), DisplayName = "Ryan Ghostling", Email = "ryanghostling@drive.com", Roles = [roles[0]] },
            new() { Id = Guid.NewGuid(), DisplayName = "Tventin Karantino", Email = "tventinkarantino@reservoir.com", Roles = [roles[0], roles[2]] },
        };

        await dbContext.UserRoles.AddRangeAsync(roles, cancellationToken);
        await dbContext.Users.AddRangeAsync(users, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}