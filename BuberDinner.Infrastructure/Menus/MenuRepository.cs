using BuberDinner.Application.Menus.Interfaces;
using BuberDinner.Domain.MenuAggregates.Entities;
using BuberDinner.Infrastructure.Common;

namespace BuberDinner.Infrastructure.Menus;

public class MenuRepository : IMenuRepository
{
    private readonly BuberDinnerDbContext _dbContext;

    public MenuRepository(BuberDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Menu menu)
    {
        _dbContext.Add(menu);
        _dbContext.SaveChanges();
    }
}