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
        var items = await _mediator.Send(new GetMenuItemsQuery());
        return Ok(items);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _mediator.Send(new GetMenuItemByIdQuery(id));
        if (item is null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateMenuItemCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateMenuItemCommand command)
    {
        if (id != command.Id) return BadRequest("Route id and body id do not match.");
        var result = await _mediator.Send(command);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _mediator.Send(new DeleteMenuItemCommand(id));
        return success ? NoContent() : NotFound();
    }
}