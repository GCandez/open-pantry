using OpenPantry.Domain.Common.Entities.Events;

namespace OpenPantry.Domain.UserManagement.Groups.Create;

public sealed record GroupCreatedEvent : EntityEvent<GroupEntity, GroupCreatedEvent.EventData>
{
    public sealed record EventData
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
    }

    public override GroupEntity DeriveNewState(GroupEntity? previousState)
    {
        return new()
        {
            Id = Data.Id,
            Name = GroupName.From(Data.Name),
            CreatedAt = Timestamp,
            UpdatedAt = Timestamp
        };
    }
}