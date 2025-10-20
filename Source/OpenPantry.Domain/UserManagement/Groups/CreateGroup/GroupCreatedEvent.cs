using OpenPantry.Domain.Common.Entities;

namespace OpenPantry.Domain.UserManagement.Groups.CreateGroup;

public sealed record GroupCreatedEvent : EntityEvent<GroupEntity, GroupCreatedEvent.EventData>
{
    public sealed record EventData
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
    }

    public override GroupEntity Apply(GroupEntity? previousState)
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