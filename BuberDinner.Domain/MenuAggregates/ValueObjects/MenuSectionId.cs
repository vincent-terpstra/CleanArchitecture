namespace BuberDinner.Domain.MenuAggregates.ValueObjects;

public class MenuSectionId : EntityId<MenuSectionId>
{
    public MenuSectionId(Guid value) : base(value)
    {
    }

    public static MenuSectionId New() => new(Guid.NewGuid());
}