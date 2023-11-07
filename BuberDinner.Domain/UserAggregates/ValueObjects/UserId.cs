namespace BuberDinner.Domain.UserAggregates.ValueObjects;

public class UserId : EntityId<UserId>
{
    public UserId(Guid value) : base(value)
    {
    }

    public static UserId New() => new(Guid.NewGuid());
}