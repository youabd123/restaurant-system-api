using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Application.Features.MenuItems.DTOs;

public class MenuItemDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public bool IsAvailable { get; set; }

    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }
}
