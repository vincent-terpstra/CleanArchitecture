using BuberDinner.Api.Common;
using BuberDinner.Application.Menus.Commands;
using BuberDinner.Contracts.Menu;
using BuberDinner.Domain.MenuAggregates.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Menus;

[Route("hosts/{hostId}/menus")]
public class MenusController : ApiControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
    {
        var command = Mapper.Map<CreateMenuCommand>((request, hostId));
        var createMenuResult = await Sender.Send(command);
        return CreatedAtActionOrProblem<Menu, MenuResponse>(createMenuResult,
            nameof(GetMenu), menu => new {menu.HostId, MenuId = menu.Id});
    }

    [HttpGet("{menuId}")]
    public async Task<IActionResult> GetMenu(string hostId, string menuId)
    {
        await Task.CompletedTask;
        return Ok();
    }
}