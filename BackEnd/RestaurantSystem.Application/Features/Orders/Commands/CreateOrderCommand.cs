using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Application.Features.Orders.DTOs;
using RestaurantSystem.Domain.Entities;

namespace RestaurantSystem.Application.Features.Orders.Commands;

public record CreateOrderCommand(
    string CustomerName,
    string CustomerEmail,
    List<CreateOrderItemDto> OrderItems
) : IRequest<OrderDto?>;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDto?>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMenuItemRepository _menuItemRepository;

    public CreateOrderCommandHandler(
        IOrderRepository orderRepository,
        IMenuItemRepository menuItemRepository)
    {
        _orderRepository = orderRepository;
        _menuItemRepository = menuItemRepository;
    }

    public async Task<OrderDto?> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        if (request.OrderItems.Count == 0)
        {
            return null;
        }

        var orderItems = new List<OrderItem>();

        foreach (var item in request.OrderItems)
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(item.MenuItemId);

            if (menuItem is null)
            {
                return null;
            }

            orderItems.Add(new OrderItem
            {
                MenuItemId = item.MenuItemId,
                Quantity = item.Quantity,
                UnitPrice = menuItem.Price
            });
        }

        var order = new Order
        {
            CustomerName = request.CustomerName,
            CustomerEmail = request.CustomerEmail,
            CreatedAt = DateTime.UtcNow,
            Status = "Pending",
            OrderItems = orderItems
        };

        var createdOrder = await _orderRepository.CreateAsync(order);

        return new OrderDto
        {
            Id = createdOrder.Id,
            CustomerName = createdOrder.CustomerName,
            CustomerEmail = createdOrder.CustomerEmail,
            CreatedAt = createdOrder.CreatedAt,
            Status = createdOrder.Status,
            OrderItems = createdOrder.OrderItems.Select(orderItem => new OrderItemDto
            {
                Id = orderItem.Id,
                MenuItemId = orderItem.MenuItemId,
                MenuItemName = orderItem.MenuItem?.Name,
                Quantity = orderItem.Quantity,
                UnitPrice = orderItem.UnitPrice
            }).ToList()
        };
    }
}

