using BuberDinner.Application.Menus.Interfaces;
using BuberDinner.Domain.HostAggregates.ValueObjects;
using BuberDinner.Domain.MenuAggregates.Entities;

namespace BuberDinner.Application.Menus.Commands;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var menu = Menu.Create(
            request.Name,
            request.Description,
            new HostId(Guid.Parse(request.HostId)),
            request.Sections.ConvertAll(section => MenuSection.Create(
                section.Name,
                section.Description,
                section.Items.ConvertAll(item => MenuItem.Create(
                    item.Name,
                    item.Description
                ))
            )));
        _menuRepository.Add(menu);

        return menu;
    }
}