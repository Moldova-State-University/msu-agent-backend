using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSUAgent.Domain.Entities;

namespace MSUAgent.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);

        builder.Property(user => user.DisplayName)
            .IsRequired();

        builder.Property(user => user.Email)
            .IsRequired();

        builder.HasMany(user => user.Roles)
            .WithMany();
    }
}