using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Domain.Entities;

public class MenuItem
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public bool IsAvailable { get; set; } = true;

    public int CategoryId { get; set; }

    public Category? Category { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}

