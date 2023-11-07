namespace BuberDinner.Domain.Common.Models;

public abstract class EntityId<TSelf> : IEquatable<EntityId<TSelf>>
{
    protected EntityId(Guid value)
        => Value = value;

    public Guid Value { get; init; }

    public bool Equals(EntityId<TSelf>? other)
    {
        return other is not null && other.Value == Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is EntityId<TSelf> right && Equals(right);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(EntityId<TSelf> left, EntityId<TSelf>? right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(EntityId<TSelf> left, EntityId<TSelf>? right)
    {
        return !left.Equals(right);
    }
}