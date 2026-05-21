using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Application.Features.Orders.DTOs;

public class OrderDto
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public string CustomerEmail { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public string Status { get; set; } = string.Empty;

    public List<OrderItemDto> OrderItems { get; set; } = new();
}

