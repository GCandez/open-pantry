using OpenPantry.Domain.Common.Entities.Actions;
using OpenPantry.Domain.Common.Results;

namespace OpenPantry.Domain.UserManagement.Users.ChangeName;

public sealed class ChangeUserNameAction : EntityAction<UserEntity, ChangeUserNameAction.Error, UserNameChangedEvent>
{
    public required UserName NewName { get; init; }

    public enum Error
    {
        SameName
    }

    protected override Result<(UserEntity NewState, UserNameChangedEvent ResultingEvent), Error> DeriveNewState(UserEntity? previousState)
    {
        if (previousState is null)
            throw new PreviousEntityStateNullException<ChangeUserNameAction>();

        if (previousState.Name == NewName)
            return Error.SameName;

        var newState = previousState with
        {
            Name = NewName,
            UpdatedAt = Timestamp
        };

        var @event = new UserNameChangedEvent
        {
            Id = Guid.CreateVersion7(Timestamp),
            Timestamp = Timestamp,
            Data = new()
            {
                NewUserName = newState.Name.Value
            }
        };

        return (newState, @event);
    }
}