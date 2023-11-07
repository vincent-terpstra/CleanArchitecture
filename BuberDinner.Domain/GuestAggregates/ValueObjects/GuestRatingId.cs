namespace BuberDinner.Domain.GuestAggregates.ValueObjects;

public class GuestRatingId : EntityId<GuestRatingId>
{
    public GuestRatingId(Guid value) : base(value)
    {
    }

    public static GuestRatingId New() => new(Guid.NewGuid());
}