using OpenPantry.Domain.Common.Entities.Actions;
using OpenPantry.Domain.Common.Results;

namespace OpenPantry.Domain.UserManagement.Groups.ChangeName;

public sealed class ChangeGroupNameAction : EntityAction<GroupEntity, ChangeGroupNameAction.Error, GroupNameChangedEvent>
{
    public enum Error
    {
        SameName
    }

    public required GroupName NewName { get; init; }

    protected override Result<(GroupEntity NewState, GroupNameChangedEvent ResultingEvent), Error> DeriveNewState(GroupEntity? previousState)
    {
        previousState.ThrowIfNull(this);

        if (previousState.Name == NewName)
            return Error.SameName;

        var newwState = previousState with
        {
            Name = NewName,
            UpdatedAt = Timestamp
        };

        var @event = new GroupNameChangedEvent
        {
            Id = Guid.CreateVersion7(Timestamp),
            Timestamp = Timestamp,
            Data = new()
            {
                NewName = NewName.Value
            }
        };

        return (newwState, @event);
    }
}