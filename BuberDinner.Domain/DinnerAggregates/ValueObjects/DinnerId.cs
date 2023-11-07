namespace BuberDinner.Domain.DinnerAggregates.ValueObjects;

public class DinnerId : EntityId<DinnerId>
{
    public DinnerId(Guid value) : base(value)
    {
    }

    public static DinnerId New() => new(Guid.NewGuid());
}