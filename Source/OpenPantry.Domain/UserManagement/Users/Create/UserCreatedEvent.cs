using OpenPantry.Domain.Common.Entities.Events;

namespace OpenPantry.Domain.UserManagement.Users.Create;

public sealed record UserCreatedEvent : EntityEvent<UserEntity, UserCreatedEvent.EventData>
{
    public override UserEntity DeriveNewState(UserEntity? previousState)
    {
        return new()
        {
            Id = Data.Id,
            Name = UserName.From(Data.Name),
            CreatedAt = Timestamp,
            UpdatedAt = Timestamp
        };
    }

    public sealed record EventData
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
    }
}