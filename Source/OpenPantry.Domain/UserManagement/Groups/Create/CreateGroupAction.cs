using OpenPantry.Domain.Common.Entities.Actions;

namespace OpenPantry.Domain.UserManagement.Groups.Create;

public sealed class CreateGroupAction : EntityAction<GroupEntity, GroupCreatedEvent>
{
    public required GroupName Name { get; init; }

    protected override (GroupEntity NewState, GroupCreatedEvent ResultingEvent) DeriveNewState(GroupEntity? previousState)
    {
        var group = new GroupEntity
        {
            Id = Guid.CreateVersion7(Timestamp),
            Name = Name,
            CreatedAt = Timestamp,
            UpdatedAt = Timestamp,
            Members = []
        };

        var @event = new GroupCreatedEvent
        {
            Id = Guid.CreateVersion7(Timestamp),
            Timestamp = Timestamp,
            Data = new()
            {
                Id = group.Id,
                Name = group.Name.Value
            }
        };

        return (group, @event);
    }
}