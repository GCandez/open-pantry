using OpenPantry.Domain.Common.Entities;
using OpenPantry.Domain.UserManagement.Users.ValueObjects;

namespace OpenPantry.Domain.UserManagement.Users;

public sealed record UserEntity : Entity<UserEntity>
{
    public required UserName Name { get; init; }
}