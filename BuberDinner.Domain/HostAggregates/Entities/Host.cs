using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregates.ValueObjects;
using BuberDinner.Domain.HostAggregates.ValueObjects;
using BuberDinner.Domain.MenuAggregates.ValueObjects;
using BuberDinner.Domain.UserAggregates.ValueObjects;

namespace BuberDinner.Domain.HostAggregates.Entities;

public class Host : Entity<HostId>
{
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuId> _menuIds = new();

    private Host()
    {
    }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Email { get; set; }

    public string ProfileImage { get; set; }

    public required AverageRating AverageRating { get; set; }
    public UserId UserId { get; set; }

    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();

    public required DateTime CreatedDateTime { get; init; }
    public required DateTime UpdatedDateTime { get; set; }
}