using BuberDinner.Domain.MenuAggregates.Events;

namespace BuberDinner.Application.Menus.EventHandler;

public class DummyEventHandler : INotificationHandler<MenuCreatedEvent>
{
    public Task Handle(MenuCreatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}