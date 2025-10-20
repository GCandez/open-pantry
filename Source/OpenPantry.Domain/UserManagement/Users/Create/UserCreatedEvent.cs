using OpenPantry.Domain.Common.Entities;

namespace OpenPantry.Domain.UserManagement.Users.Create;

public sealed record UserCreatedEvent : EntityEvent<UserEntity, UserCreatedEvent.EventData>
{
    public sealed record EventData
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
    }

    public override UserEntity Apply(UserEntity? previousState)
    {
        return new()
        {
            Id = Data.Id,
            Name = UserName.From(Data.Name),
            CreatedAt = Timestamp,
            UpdatedAt = Timestamp
        };
    }
}