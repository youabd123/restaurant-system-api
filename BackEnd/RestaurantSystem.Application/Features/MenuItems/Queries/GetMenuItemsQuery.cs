using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Application.Features.MenuItems.DTOs;

namespace RestaurantSystem.Application.Features.MenuItems.Queries;

public record GetMenuItemsQuery : IRequest<List<MenuItemDto>>;

public class GetMenuItemsQueryHandler : IRequestHandler<GetMenuItemsQuery, List<MenuItemDto>>
{
    private readonly IMenuItemRepository _menuItemRepository;

    public GetMenuItemsQueryHandler(IMenuItemRepository menuItemRepository)
    {
        _menuItemRepository = menuItemRepository;
    }

    public async Task<List<MenuItemDto>> Handle(GetMenuItemsQuery request, CancellationToken cancellationToken)
    {
        var menuItems = await _menuItemRepository.GetAllAsync();

        return menuItems
            .Select(menuItem => new MenuItemDto
            {
                Id = menuItem.Id,
                Name = menuItem.Name,
                Description = menuItem.Description,
                Price = menuItem.Price,
                IsAvailable = menuItem.IsAvailable,
                CategoryId = menuItem.CategoryId,
                CategoryName = menuItem.Category?.Name
            })
            .ToList();
    }
}

