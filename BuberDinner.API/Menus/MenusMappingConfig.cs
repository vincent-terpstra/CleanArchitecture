using BuberDinner.Application.Menus.Commands;
using BuberDinner.Contracts.Menu;
using BuberDinner.Domain.MenuAggregates.Entities;
using Mapster;
using MenuItem = BuberDinner.Domain.MenuAggregates.Entities.MenuItem;
using MenuSection = BuberDinner.Domain.MenuAggregates.Entities.MenuSection;

namespace BuberDinner.Api.Menus;

public class MenusMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest request, string hostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.hostId)
            .Map(dest => dest, src => src.request);

        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}