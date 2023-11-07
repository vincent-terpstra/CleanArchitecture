namespace BuberDinner.Domain.MenuAggregates.ValueObjects;

public class MenuId : EntityId<MenuId>
{
    public MenuId(Guid value) : base(value)
    {
    }

    public static MenuId New() => new(Guid.NewGuid());
}