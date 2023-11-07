using BuberDinner.Domain.MenuAggregates.Entities;

namespace BuberDinner.Application.Menus.Interfaces;

public interface IMenuRepository
{
    public void Add(Menu menu);
}