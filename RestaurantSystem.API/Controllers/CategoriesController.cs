using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.Application.Features.Categories.Commands;
using RestaurantSystem.Application.Features.Categories.Queries;

namespace RestaurantSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _mediator.Send(new GetCategoriesQuery());

        return Ok(categories);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _mediator.Send(new GetCategoryByIdQuery(id));

        if (category is null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryCommand command)
    {
        var createdCategory = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = createdCategory.Id }, createdCategory);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateCategoryCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("Route id and body id do not match.");
        }

        var updatedCategory = await _mediator.Send(command);

        if (updatedCategory is null)
        {
            return NotFound();
        }

        return Ok(updatedCategory);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _mediator.Send(new DeleteCategoryCommand(id));

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
