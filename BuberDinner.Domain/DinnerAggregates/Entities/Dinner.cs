using BuberDinner.Domain.BillAggregates.ValueObjects;
using BuberDinner.Domain.DinnerAggregates.Enums;
using BuberDinner.Domain.DinnerAggregates.ValueObjects;
using BuberDinner.Domain.HostAggregates.ValueObjects;
using BuberDinner.Domain.MenuAggregates.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregates.Entities;

public class Dinner : Entity<DinnerId>
{
    private Dinner()
    {
    }

    private List<Reservation> _reservations { get; } = new();

    public required string Name { get; init; }
    public required string Description { get; init; }

    public required DateTime StartDateTime { get; set; }
    public required DateTime EndDateTime { get; set; }

    public required DateTime? StartedDateTime { get; set; }
    public required DateTime? EndedDateTime { get; set; }

    public DinnerStatus Status { get; set; } = DinnerStatus.Upcoming;

    public bool IsPublic { get; set; } = true;

    public required int MaxGuests { get; set; }

    public required Price Price { get; set; }

    public required HostId HostId { get; init; }
    public required MenuId MenuId { get; init; }

    public string ImageUrl { get; set; }
    public Location Location { get; set; }

    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

    public required DateTime CreatedDateTime { get; init; }
    public required DateTime UpdatedDateTime { get; set; }

    public static Dinner Create(string name, string description, Price price, HostId hostId, MenuId menuId,
        Location location)
    {
        return new Dinner
        {
            Id = DinnerId.New(),
            Name = name,
            Description = description,
            StartDateTime = default,
            EndDateTime = default,
            StartedDateTime = null,
            EndedDateTime = null,
            MaxGuests = 0,
            Price = price,
            HostId = hostId,
            MenuId = menuId,
            Location = location,
            CreatedDateTime = DateTime.UtcNow,
            UpdatedDateTime = DateTime.UtcNow
        };
    }
}