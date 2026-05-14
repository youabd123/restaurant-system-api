using MediatR;
using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Application.Features.MenuItems.DTOs;
using RestaurantSystem.Domain.Entities;

namespace RestaurantSystem.Application.Features.MenuItems.Commands;

public record CreateMenuItemCommand(
    string Name,
    string? Description,
    decimal Price,
    bool IsAvailable,
    int CategoryId) : IRequest<MenuItemDto>;

public class CreateMenuItemCommandHandler : IRequestHandler<CreateMenuItemCommand, MenuItemDto>
{
    private readonly IMenuItemRepository _menuItemRepository;

    public CreateMenuItemCommandHandler(IMenuItemRepository menuItemRepository)
    {
        _menuItemRepository = menuItemRepository;
    }

    public async Task<MenuItemDto> Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
    {
        var menuItem = new MenuItem
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            IsAvailable = request.IsAvailable,
            CategoryId = request.CategoryId
        };

        var createdMenuItem = await _menuItemRepository.CreateAsync(menuItem);

        return new MenuItemDto
        {
            Id = createdMenuItem.Id,
            Name = createdMenuItem.Name,
            Description = createdMenuItem.Description,
            Price = createdMenuItem.Price,
            IsAvailable = createdMenuItem.IsAvailable,
            CategoryId = createdMenuItem.CategoryId,
            CategoryName = createdMenuItem.Category?.Name
        };
    }
}
