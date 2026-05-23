using MediatR;
using Microsoft.AspNetCore.Identity;
using RestaurantSystem.Domain.Entities;

namespace RestaurantSystem.Application.Features.Auth.Commands;

public record RegisterCommand(string FullName, string Email, string Password) : IRequest<AuthDto>;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthDto>
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterCommandHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<AuthDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = new AppUser
        {
            FullName = request.FullName,
            Email = request.Email,
            UserName = request.Email
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception(errors);
        }

        await _userManager.AddToRoleAsync(user, "User");

        return new AuthDto
        {
            Email = user.Email!,
            FullName = user.FullName,
            Roles = await _userManager.GetRolesAsync(user)
        };
    }
}