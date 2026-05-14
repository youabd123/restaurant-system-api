using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Application.Features.Orders.DTOs;

namespace RestaurantSystem.Application.Features.Orders.Queries;

public record GetOrderByIdQuery(int Id) : IRequest<OrderDto?>;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto?>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id);

        if (order is null)
        {
            return null;
        }

        return new OrderDto
        {
            Id = order.Id,
            CustomerName = order.CustomerName,
            CustomerEmail = order.CustomerEmail,
            CreatedAt = order.CreatedAt,
            Status = order.Status,
            OrderItems = order.OrderItems.Select(orderItem => new OrderItemDto
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
