using FluentAssertions;
using Moq;
using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Application.Features.Orders.Commands;
using RestaurantSystem.Application.Features.Orders.DTOs;
using RestaurantSystem.Application.Features.Orders.Queries;
using RestaurantSystem.Domain.Entities;

namespace RestaurantSystem.Tests;

public class OrderHandlerTests
{
    private readonly Mock<IOrderRepository> _mockOrderRepo;
    private readonly Mock<IMenuItemRepository> _mockMenuItemRepo;

    public OrderHandlerTests()
    {
        _mockOrderRepo = new Mock<IOrderRepository>();
        _mockMenuItemRepo = new Mock<IMenuItemRepository>();
    }

    [Fact]
    public async Task CreateOrder_ShouldReturnOrderDto_WhenValid()
    {
        var command = new CreateOrderCommand("Anna Svensson", "anna@test.se", new List<CreateOrderItemDto>
        {
            new CreateOrderItemDto { MenuItemId = 1, Quantity = 2 }
        });

        _mockMenuItemRepo.Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(new MenuItem { Id = 1, Name = "Margherita", Price = 95m });

        _mockOrderRepo.Setup(r => r.CreateAsync(It.IsAny<Order>()))
            .ReturnsAsync((Order o) => { o.Id = 1; return o; });

        var handler = new CreateOrderCommandHandler(_mockOrderRepo.Object, _mockMenuItemRepo.Object);
        var result = await handler.Handle(command, CancellationToken.None);

        result.Should().NotBeNull();
        result!.CustomerName.Should().Be("Anna Svensson");
    }

    [Fact]
    public async Task CreateOrder_ShouldReturnNull_WhenMenuItemNotFound()
    {
        var command = new CreateOrderCommand("Anna Svensson", "anna@test.se", new List<CreateOrderItemDto>
        {
            new CreateOrderItemDto { MenuItemId = 99, Quantity = 1 }
        });

        _mockMenuItemRepo.Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((MenuItem?)null);

        var handler = new CreateOrderCommandHandler(_mockOrderRepo.Object, _mockMenuItemRepo.Object);
        var result = await handler.Handle(command, CancellationToken.None);

        result.Should().BeNull();
    }

    [Fact]
    public async Task GetOrders_ShouldReturnList()
    {
        _mockOrderRepo.Setup(r => r.GetAllAsync())
            .ReturnsAsync(new List<Order>
            {
                new Order { Id = 1, CustomerName = "Anna", CustomerEmail = "anna@test.se", Status = "Pending", OrderItems = new List<OrderItem>() },
                new Order { Id = 2, CustomerName = "Erik", CustomerEmail = "erik@test.se", Status = "Completed", OrderItems = new List<OrderItem>() }
            });

        var handler = new GetOrdersQueryHandler(_mockOrderRepo.Object);
        var result = await handler.Handle(new GetOrdersQuery(), CancellationToken.None);

        result.Should().HaveCount(2);
    }

    [Fact]
    public async Task GetOrderById_ShouldReturnDto_WhenExists()
    {
        _mockOrderRepo.Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(new Order { Id = 1, CustomerName = "Anna", CustomerEmail = "anna@test.se", Status = "Pending", OrderItems = new List<OrderItem>() });

        var handler = new GetOrderByIdQueryHandler(_mockOrderRepo.Object);
        var result = await handler.Handle(new GetOrderByIdQuery(1), CancellationToken.None);

        result.Should().NotBeNull();
        result!.CustomerName.Should().Be("Anna");
    }

    [Fact]
    public async Task GetOrderById_ShouldReturnNull_WhenNotExists()
    {
        _mockOrderRepo.Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((Order?)null);

        var handler = new GetOrderByIdQueryHandler(_mockOrderRepo.Object);
        var result = await handler.Handle(new GetOrderByIdQuery(99), CancellationToken.None);

        result.Should().BeNull();
    }

    [Fact]
    public async Task UpdateOrder_ShouldReturnUpdatedDto_WhenExists()
    {
        _mockOrderRepo.Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(new Order { Id = 1, CustomerName = "Anna", CustomerEmail = "anna@test.se", Status = "Pending", OrderItems = new List<OrderItem>() });

        var handler = new UpdateOrderCommandHandler(_mockOrderRepo.Object);
        var result = await handler.Handle(new UpdateOrderCommand(1, "Completed"), CancellationToken.None);

        result.Should().NotBeNull();
        result!.Status.Should().Be("Completed");
    }

    [Fact]
    public async Task UpdateOrder_ShouldReturnNull_WhenNotExists()
    {
        _mockOrderRepo.Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((Order?)null);

        var handler = new UpdateOrderCommandHandler(_mockOrderRepo.Object);
        var result = await handler.Handle(new UpdateOrderCommand(99, "Completed"), CancellationToken.None);

        result.Should().BeNull();
    }

    [Fact]
    public async Task DeleteOrder_ShouldReturnTrue_WhenExists()
    {
        _mockOrderRepo.Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(new Order { Id = 1, CustomerName = "Anna", OrderItems = new List<OrderItem>() });

        var handler = new DeleteOrderCommandHandler(_mockOrderRepo.Object);
        var result = await handler.Handle(new DeleteOrderCommand(1), CancellationToken.None);

        result.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteOrder_ShouldReturnFalse_WhenNotExists()
    {
        _mockOrderRepo.Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((Order?)null);

        var handler = new DeleteOrderCommandHandler(_mockOrderRepo.Object);
        var result = await handler.Handle(new DeleteOrderCommand(99), CancellationToken.None);

        result.Should().BeFalse();
    }
}