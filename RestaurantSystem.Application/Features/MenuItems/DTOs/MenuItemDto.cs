namespace RestaurantSystem.Application.Features.MenuItems.DTOs;

public record MenuItemDto(int Id, string Name, string? Description, decimal Price, int CategoryId);