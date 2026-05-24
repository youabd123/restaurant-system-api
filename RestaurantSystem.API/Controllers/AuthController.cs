using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantSystem.Application.Features.Auth.Commands;

namespace RestaurantSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
    {
        var result = await _mediator.Send(command);
        if (!result) return BadRequest("Kunde inte återställa lösenordet.");
        return Ok("Lösenordet har återställts.");
    }
}