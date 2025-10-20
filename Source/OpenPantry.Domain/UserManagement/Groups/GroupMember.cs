namespace OpenPantry.Domain.UserManagement.Groups;

public sealed record GroupMember
{
    public required Guid UserId { get; init; }
    public required DateTimeOffset JoinedAt { get; init; }
}