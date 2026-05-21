using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.Domain.Entities;

public class Order
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public string CustomerEmail { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string Status { get; set; } = "Pending";

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}

