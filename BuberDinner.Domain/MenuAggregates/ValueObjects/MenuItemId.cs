namespace BuberDinner.Domain.MenuAggregates.ValueObjects;

public class MenuItemId : EntityId<MenuItemId>
{
    public MenuItemId(Guid value) : base(value)
    {
    }

    public static MenuItemId New() => new(Guid.NewGuid());
}