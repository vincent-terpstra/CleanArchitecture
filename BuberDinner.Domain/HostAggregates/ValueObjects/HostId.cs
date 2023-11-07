namespace BuberDinner.Domain.HostAggregates.ValueObjects;

public class HostId : EntityId<HostId>
{
    public HostId(Guid value) : base(value)
    {
    }

    public static HostId New() => new(Guid.NewGuid());
}