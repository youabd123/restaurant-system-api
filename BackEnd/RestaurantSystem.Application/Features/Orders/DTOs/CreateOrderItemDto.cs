using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Application.Features.Orders.DTOs;

public class CreateOrderItemDto
{
    public int MenuItemId { get; set; }

    public int Quantity { get; set; }
}

