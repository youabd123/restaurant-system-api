using MediatR;
using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Application.Features.Orders.DTOs;

namespace RestaurantSystem.Application.Features.Orders.Queries;

public record GetOrdersQuery : IRequest<List<OrderDto>>;

public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<OrderDto>>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrdersQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetAllAsync();

        return orders.Select(order => new OrderDto
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
        }).ToList();
    }
}
