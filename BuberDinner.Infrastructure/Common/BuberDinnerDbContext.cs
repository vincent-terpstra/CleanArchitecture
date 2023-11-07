using BuberDinner.Domain.Common.Events;
using BuberDinner.Domain.MenuAggregates.Entities;
using BuberDinner.Infrastructure.Common.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BuberDinner.Infrastructure.Common;

public class BuberDinnerDbContext : DbContext
{
    private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

    public BuberDinnerDbContext(DbContextOptions<BuberDinnerDbContext> options,
        PublishDomainEventsInterceptor publishDomainEventsInterceptor) : base(options)
    {
        _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
    }

    public DbSet<Menu> Menus { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            // Ignore any lists of IDomainEvents
            .Ignore<IDomainEvent>()
            .ApplyConfigurationsFromAssembly(typeof(BuberDinnerDbContext).Assembly);


        //prevent generation of Primary Keys
        modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .Where(p => p.IsPrimaryKey())
            .ToList().ForEach(p => p.ValueGenerated = ValueGenerated.Never);

        base.OnModelCreating(modelBuilder);
    }
}