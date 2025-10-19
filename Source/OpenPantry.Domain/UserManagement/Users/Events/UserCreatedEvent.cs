using OpenPantry.Domain.Common.Entities;
using OpenPantry.Domain.UserManagement.Users.ValueObjects;

namespace OpenPantry.Domain.UserManagement.Users.Events;

public sealed record UserCreatedEvent : EntityEvent<UserEntity, UserCreatedEvent.EventData>
{
    public sealed record EventData
    {
        public required Guid UserId { get; init; }
        public required string UserName { get; init; }
    }

    public override UserEntity Apply(UserEntity? previousState)
    {
        return new()
        {
            Id = Data.UserId,
            Name = UserName.From(Data.UserName),
            CreatedAt = Timestamp,
            UpdatedAt = Timestamp
        };
    }
}