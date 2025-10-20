using System.Collections.Immutable;
using OpenPantry.Domain.Common.Entities;

namespace OpenPantry.Domain.UserManagement.Groups;

public sealed record GroupEntity : Entity<GroupEntity>
{
    public required GroupName Name { get; init; }
    public ImmutableArray<GroupMember> Members { get; init; }
}