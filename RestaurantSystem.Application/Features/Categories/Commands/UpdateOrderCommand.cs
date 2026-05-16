using MediatR;
using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Application.Features.Orders.DTOs;

namespace RestaurantSystem.Application.Features.Orders.Commands;

public record UpdateOrderCommand(int Id, string Status) : IRequest<OrderDto?>;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, OrderDto?>
{
    private readonly IOrderRepository _orderRepository;

    public UpdateOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderDto?> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id);

        if (order is null)
        {
            return null;
        }

        order.Status = request.Status;

        await _orderRepository.UpdateAsync(order);

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
