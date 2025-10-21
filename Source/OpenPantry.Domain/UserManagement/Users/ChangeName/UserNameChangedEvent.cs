using OpenPantry.Domain.Common.Entities.Events;

namespace OpenPantry.Domain.UserManagement.Users.ChangeName;

public sealed record UserNameChangedEvent : EntityEvent<UserEntity, UserNameChangedEvent.EventData>
{
    public override UserEntity DeriveNewState(UserEntity? previousState)
    {
        if (previousState is null)
            throw new InvalidOperationException("Cannot apply UserNameChangedEvent to a null UserEntity");

        return previousState with
        {
            Name = UserName.From(Data.NewUserName),
            UpdatedAt = Timestamp
        };
    }

    public sealed record EventData
    {
        public required string NewUserName { get; init; }
    }
}