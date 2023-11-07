using BuberDinner.Domain.MenuAggregates.ValueObjects;

namespace BuberDinner.Domain.MenuAggregates.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();

    private MenuSection()
    {
    }

    public string Name { get; private set; }
    public string Description { get; private set; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    public static MenuSection Create(string name, string description, List<MenuItem> items)
    {
        MenuSection menuSection = new()
        {
            Id = MenuSectionId.New(),
            Name = name,
            Description = description
        };

        menuSection._items.AddRange(items);
        return menuSection;
    }
}