namespace BuberDinner.Domain.DinnerAggregates.ValueObjects;

public class ReservationId : EntityId<ReservationId>
{
    public ReservationId(Guid value) : base(value)
    {
    }

    public static ReservationId New() => new(Guid.NewGuid());
}