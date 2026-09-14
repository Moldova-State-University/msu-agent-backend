using Microsoft.EntityFrameworkCore;
using MSUAgent.Domain.Entities;

namespace MSUAgent.Infrastructure.Persistence;

public static class RoleSeeder
{
    public static async Task SeedAsync(AppDbContext dbContext, CancellationToken cancellationToken = default)
    {
        string[] roleNames =
        [
            "Member",
            "Admin",
            "Owner"
        ];

        foreach (var roleName in roleNames)
        {
            var roleExists = await dbContext.UserRoles
                .AnyAsync(
                    role => role.Name == roleName,
                    cancellationToken);

            if (roleExists)
            {
                continue;
            }

            dbContext.UserRoles.Add(
                new UserRole
                {
                    Name = roleName
                });
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}