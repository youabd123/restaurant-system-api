using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.Application.Features.Orders.Commands;
using RestaurantSystem.Application.Features.Orders.Queries;

namespace RestaurantSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _mediator.Send(new GetOrdersQuery());

        return Ok(orders);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await _mediator.Send(new GetOrderByIdQuery(id));

        if (order is null)
        {
            return NotFound();
        }

        return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderCommand command)
    {
        var createdOrder = await _mediator.Send(command);

        if (createdOrder is null)
        {
            return BadRequest("Order must contain valid menu items.");
        }

        return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, createdOrder);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _mediator.Send(new DeleteOrderCommand(id));

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
