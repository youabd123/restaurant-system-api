using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.Application.Features.MenuItems.Commands;
using RestaurantSystem.Application.Features.MenuItems.Queries;

namespace RestaurantSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public MenuItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var menuItems = await _mediator.Send(new GetMenuItemsQuery());

        return Ok(menuItems);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var menuItem = await _mediator.Send(new GetMenuItemByIdQuery(id));

        if (menuItem is null)
        {
            return NotFound();
        }

        return Ok(menuItem);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMenuItemCommand command)
    {
        var createdMenuItem = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = createdMenuItem.Id }, createdMenuItem);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateMenuItemCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("Route id and body id do not match.");
        }

        var updatedMenuItem = await _mediator.Send(command);

        if (updatedMenuItem is null)
        {
            return NotFound();
        }

        return Ok(updatedMenuItem);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _mediator.Send(new DeleteMenuItemCommand(id));

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
