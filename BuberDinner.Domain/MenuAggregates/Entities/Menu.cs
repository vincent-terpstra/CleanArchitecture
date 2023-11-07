using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregates.ValueObjects;
using BuberDinner.Domain.HostAggregates.ValueObjects;
using BuberDinner.Domain.MenuAggregates.Events;
using BuberDinner.Domain.MenuAggregates.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregates.ValueObjects;

namespace BuberDinner.Domain.MenuAggregates.Entities;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    private List<MenuSection> _sections = new();

    private Menu()
    {
    }

    public string Name { get; private set; }
    public string Description { get; private set; }

    public AverageRating AverageRating { get; private set; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public HostId HostId { get; private set; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public static Menu Create(string name, string description, HostId hostId, List<MenuSection> menuSections)
    {
        var menu = new Menu
        {
            Id = MenuId.New(),
            Name = name,
            Description = description,
            HostId = hostId,
            AverageRating = AverageRating.CreateNew(3.5, 1),
            _sections = menuSections,
            CreatedDateTime = DateTime.UtcNow,
            UpdatedDateTime = DateTime.UtcNow
        };

        menu.AddDomainEvent(new MenuCreatedEvent(menu));

        return menu;
    }
}