using BuberDinner.Domain.MenuAggregates.Entities;

namespace BuberDinner.Domain.MenuAggregates.Events;

public record MenuCreatedEvent(Menu Menu) : IDomainEvent;