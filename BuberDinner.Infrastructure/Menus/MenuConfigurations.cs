using BuberDinner.Domain.DinnerAggregates.ValueObjects;
using BuberDinner.Domain.HostAggregates.ValueObjects;
using BuberDinner.Domain.MenuAggregates.Entities;
using BuberDinner.Domain.MenuAggregates.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregates.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Menus;

public class MenuConfigurations : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        builder.OwnsMany(m => m.DinnerIds, ConfigureMenuDinnerIds);
        builder.OwnsMany(m => m.MenuReviewIds, ConfigureMenuReviewIds);

        builder.Metadata.FindNavigation(nameof(Menu.Sections))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
        builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
        builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuReviewIds(OwnedNavigationBuilder<Menu, MenuReviewId> menuReviewIdsBuilder)
    {
        menuReviewIdsBuilder.ToTable("MenuReviewIds");
        menuReviewIdsBuilder.WithOwner().HasForeignKey("MenuId");

        menuReviewIdsBuilder.HasKey("Id");
        menuReviewIdsBuilder.Property(d => d.Value)
            .HasColumnName("MenuReviewId")
            .ValueGeneratedNever();
    }

    private void ConfigureMenuDinnerIds(OwnedNavigationBuilder<Menu, DinnerId> dinnerIdsBuilder)
    {
        dinnerIdsBuilder.ToTable("MenuDinnerIds");
        dinnerIdsBuilder.WithOwner().HasForeignKey("MenuId");

        dinnerIdsBuilder.HasKey("Id");
        dinnerIdsBuilder.Property(d => d.Value)
            .HasColumnName("DinnerId")
            .ValueGeneratedNever();
    }


    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus"); // explicit (menus is default)

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedNever() // value generated in the command
            .HasConversion(id => id.Value,
                value => new MenuId(value));

        builder.Property(m => m.Name)
            .HasMaxLength(40);
        builder.Property(m => m.Description)
            .HasMaxLength(200);

        builder.Property(m => m.HostId)
            .HasConversion(id => id.Value,
                value => new HostId(value));

        builder.OwnsMany(m => m.Sections, ConfigureMenusSections);
        builder.OwnsOne(m => m.AverageRating);
    }

    private void ConfigureMenusSections(OwnedNavigationBuilder<Menu, MenuSection> menuSectionBuilder)
    {
        menuSectionBuilder.ToTable("MenuSections");
        menuSectionBuilder.WithOwner().HasForeignKey("MenuId");
        menuSectionBuilder.HasKey(nameof(MenuSection.Id), "MenuId");

        menuSectionBuilder.Property(menuSection => menuSection.Id)
            .HasColumnName("MenuSectionId")
            .ValueGeneratedNever()
            .HasConversion(id => id.Value,
                value => new MenuSectionId(value));

        menuSectionBuilder.Property(menuSection => menuSection.Name)
            .HasMaxLength(40);
        menuSectionBuilder.Property(menuSection => menuSection.Description)
            .HasMaxLength(200);

        menuSectionBuilder.OwnsMany(s => s.Items, ConfigureMenuItems);
        menuSectionBuilder.Navigation(s => s.Items)
            .Metadata.SetField("_items");
        menuSectionBuilder.Navigation(s => s.Items)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuItems(OwnedNavigationBuilder<MenuSection, MenuItem> menuItemBuilder)
    {
        menuItemBuilder.ToTable("MenuItems");
        menuItemBuilder.WithOwner().HasForeignKey("MenuSectionId", "MenuId");
        menuItemBuilder.HasKey(nameof(MenuSection.Id), "MenuSectionId", "MenuId");

        menuItemBuilder.Property(menuItem => menuItem.Id)
            .HasColumnName("MenuItemId")
            .ValueGeneratedNever()
            .HasConversion(id => id.Value,
                value => new MenuItemId(value));

        menuItemBuilder.Property(menuItem => menuItem.Name)
            .HasMaxLength(40);
        menuItemBuilder.Property(menuItem => menuItem.Description)
            .HasMaxLength(200);
    }
}