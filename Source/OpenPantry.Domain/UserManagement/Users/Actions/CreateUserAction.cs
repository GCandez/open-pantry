using OpenPantry.Domain.Common.Entities;
using OpenPantry.Domain.UserManagement.Users.Events;
using OpenPantry.Domain.UserManagement.Users.ValueObjects;

namespace OpenPantry.Domain.UserManagement.Users.Actions;

public sealed class CreateUserAction : EntityAction<UserEntity, UserCreatedEvent>
{
    public required UserName Name { get; init; }

    protected override (UserEntity NewState, UserCreatedEvent ResultingEvent) DeriveNewState(UserEntity? previousState)
    {
        var user = new UserEntity
        {
            Id = Guid.CreateVersion7(Timestamp),
            Name = Name,
            CreatedAt = Timestamp,
            UpdatedAt = Timestamp
        };

        var @event = new UserCreatedEvent
        {
            Id = Guid.CreateVersion7(Timestamp),
            Timestamp = Timestamp,
            Data = new()
            {
                UserId = user.Id,
                UserName = user.Name.Value
            }
        };

        return (user, @event);
    }
}