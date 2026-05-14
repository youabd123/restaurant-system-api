using System;
using MediatR;
using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Application.Features.MenuItems.DTOs;

namespace RestaurantSystem.Application.Features.MenuItems.Commands;

public record UpdateMenuItemCommand(
    int Id,
    string Name,
    string? Description,
    decimal Price,
    bool IsAvailable,
    int CategoryId) : IRequest<MenuItemDto?>;

public class UpdateMenuItemCommandHandler : IRequestHandler<UpdateMenuItemCommand, MenuItemDto?>
{
    private readonly IMenuItemRepository _menuItemRepository;

    public UpdateMenuItemCommandHandler(IMenuItemRepository menuItemRepository)
    {
        _menuItemRepository = menuItemRepository;
    }

    public async Task<MenuItemDto?> Handle(UpdateMenuItemCommand request, CancellationToken cancellationToken)
    {
        var menuItem = await _menuItemRepository.GetByIdAsync(request.Id);

        if (menuItem is null)
        {
            return null;
        }

        menuItem.Name = request.Name;
        menuItem.Description = request.Description;
        menuItem.Price = request.Price;
        menuItem.IsAvailable = request.IsAvailable;
        menuItem.CategoryId = request.CategoryId;

        await _menuItemRepository.UpdateAsync(menuItem);

        return new MenuItemDto
        {
            Id = menuItem.Id,
            Name = menuItem.Name,
            Description = menuItem.Description,
            Price = menuItem.Price,
            IsAvailable = menuItem.IsAvailable,
            CategoryId = menuItem.CategoryId,
            CategoryName = menuItem.Category?.Name
        };
    }
}
