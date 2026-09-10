using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSUAgent.Domain.Entities;

namespace MSUAgent.Infrastructure.Persistence.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    private static readonly Guid MemberRoleId =
        Guid.Parse("9eaedadf-ba46-4230-8b7e-85315d349253");

    private static readonly Guid AdminRoleId =
        Guid.Parse("ea296a63-efba-43dc-ab83-433e9a68b1c8");

    private static readonly Guid OwnerRoleId =
        Guid.Parse("a6ffec69-0d9d-4798-be3f-099d9c587fc4");

    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(role => role.Id);

        builder.Property(role => role.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(role => role.Name)
            .IsUnique();

        builder.HasData(
            new UserRole
            {
                Id = MemberRoleId,
                Name = "Member"
            },
            new UserRole
            {
                Id = AdminRoleId,
                Name = "Admin"
            },
            new UserRole
            {
                Id = OwnerRoleId,
                Name = "Owner"
            });
    }
}