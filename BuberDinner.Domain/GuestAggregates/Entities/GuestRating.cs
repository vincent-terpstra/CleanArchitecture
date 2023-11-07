using BuberDinner.Domain.DinnerAggregates.ValueObjects;
using BuberDinner.Domain.GuestAggregates.ValueObjects;
using BuberDinner.Domain.HostAggregates.ValueObjects;

namespace BuberDinner.Domain.GuestAggregates.Entities;

public class GuestRating : Entity<GuestRatingId>
{
    private GuestRating()
    {
    }

    public required HostId HostId { get; set; }
    public required DinnerId DinnerId { get; set; }
    public float Rating { get; set; }

    public required DateTime CreatedDateTime { get; init; }
    public required DateTime UpdatedDateTime { get; set; }

    public static GuestRating Create(HostId hostId, DinnerId dinnerId)
    {
        return new GuestRating
        {
            Id = GuestRatingId.New(),
            HostId = hostId,
            DinnerId = dinnerId,
            CreatedDateTime = DateTime.UtcNow,
            UpdatedDateTime = DateTime.UtcNow
        };
    }
}