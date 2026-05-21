using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Application.Features.MenuItems.DTOs;

namespace RestaurantSystem.Application.Features.MenuItems.Queries;

public record GetMenuItemByIdQuery(int Id) : IRequest<MenuItemDto?>;

public class GetMenuItemByIdQueryHandler : IRequestHandler<GetMenuItemByIdQuery, MenuItemDto?>
{
    private readonly IMenuItemRepository _menuItemRepository;

    public GetMenuItemByIdQueryHandler(IMenuItemRepository menuItemRepository)
    {
        _menuItemRepository = menuItemRepository;
    }

    public async Task<MenuItemDto?> Handle(GetMenuItemByIdQuery request, CancellationToken cancellationToken)
    {
        var menuItem = await _menuItemRepository.GetByIdAsync(request.Id);

        if (menuItem is null)
        {
            return null;
        }

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
