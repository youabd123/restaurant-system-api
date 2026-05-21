using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using RestaurantSystem.Application.Common.Interfaces;

namespace RestaurantSystem.Application.Features.Orders.Commands;

public record DeleteOrderCommand(int Id) : IRequest<bool>;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
{
    private readonly IOrderRepository _orderRepository;

    public DeleteOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.Id);

        if (order is null)
        {
            return false;
        }

        await _orderRepository.DeleteAsync(order);

        return true;
    }
}
