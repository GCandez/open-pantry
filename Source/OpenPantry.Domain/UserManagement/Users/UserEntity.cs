using OpenPantry.Domain.Common.Entities;

namespace OpenPantry.Domain.UserManagement.Users;

public sealed class UserEntity : Entity<UserEntity>
{
    public required UserName Name { get; init; }
}