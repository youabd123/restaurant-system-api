using MediatR;
using Microsoft.AspNetCore.Identity;
using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Domain.Entities;

namespace RestaurantSystem.Application.Features.Auth.Commands;

public record LoginCommand(string Email, string Password) : IRequest<AuthDto>;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthDto>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IJwtService _jwtService;

    public LoginCommandHandler(UserManager<AppUser> userManager, IJwtService jwtService)
    {
        _userManager = userManager;
        _jwtService = jwtService;
    }

    public async Task<AuthDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        var roles = await _userManager.GetRolesAsync(user);
        var token = _jwtService.GenerateToken(user, roles);

        return new AuthDto
        {
            Token = token,
            Email = user.Email!,
            FullName = user.FullName,
            Roles = roles
        };
    }
}