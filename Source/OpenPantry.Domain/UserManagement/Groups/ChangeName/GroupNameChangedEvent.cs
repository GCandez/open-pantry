using OpenPantry.Domain.Common.Entities.Events;

namespace OpenPantry.Domain.UserManagement.Groups.ChangeName;

public sealed record GroupNameChangedEvent : EntityEvent<GroupEntity, GroupNameChangedEvent.EventData>
{
    public override GroupEntity DeriveNewState(GroupEntity? previousState)
    {
        previousState.ThrowIfNull(this);

        return previousState with
        {
            Name = GroupName.From(Data.NewName)
        };
    }

    public sealed record EventData
    {
        public required string NewName { get; init; }
    }
}