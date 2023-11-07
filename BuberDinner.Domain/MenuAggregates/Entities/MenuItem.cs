using BuberDinner.Domain.MenuAggregates.ValueObjects;

namespace BuberDinner.Domain.MenuAggregates.Entities;

public sealed class MenuItem : Entity<MenuItemId>
{
    private MenuItem()
    {
    }

    public string Name { get; private set; }
    public string Description { get; private set; }

    public static MenuItem Create(string name, string description)
        => new()
        {
            Id = MenuItemId.New(),
            Name = name,
            Description = description
        };
}