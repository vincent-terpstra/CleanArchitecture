namespace BuberDinner.Domain.BillAggregates.ValueObjects;

public class BillId : EntityId<BillId>
{
    public BillId(Guid value) : base(value)
    {
    }

    public static BillId New() => new(Guid.NewGuid());
}