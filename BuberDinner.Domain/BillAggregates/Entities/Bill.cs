using BuberDinner.Domain.BillAggregates.ValueObjects;
using BuberDinner.Domain.DinnerAggregates.ValueObjects;
using BuberDinner.Domain.GuestAggregates.ValueObjects;
using BuberDinner.Domain.HostAggregates.ValueObjects;

namespace BuberDinner.Domain.BillAggregates.Entities;

public class Bill : Entity<BillId>
{
    private Bill()
    {
    }

    public required DinnerId DinnerId { get; init; }
    public required GuestId GuestId { get; init; }
    public required HostId HostId { get; init; }

    public required Price Price { get; init; }

    public required DateTime CreatedDateTime { get; init; }
    public required DateTime UpdatedDateTime { get; set; }

    public static Bill Create(DinnerId dinnerId, GuestId guestId, HostId hostId, Price price)
    {
        return new Bill
        {
            Id = BillId.New(),
            DinnerId = dinnerId,
            GuestId = guestId,
            HostId = hostId,
            Price = price,
            CreatedDateTime = DateTime.UtcNow,
            UpdatedDateTime = DateTime.UtcNow
        };
    }
}