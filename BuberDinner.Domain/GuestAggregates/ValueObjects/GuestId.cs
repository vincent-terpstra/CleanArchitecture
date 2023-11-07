namespace BuberDinner.Domain.GuestAggregates.ValueObjects;

public class GuestId : EntityId<GuestId>
{
    public GuestId(Guid value) : base(value)
    {
    }

    public static GuestId New() => new(Guid.NewGuid());
}