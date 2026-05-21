using FluentAssertions;
using Moq;
using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Application.Features.MenuItems.Commands;
using RestaurantSystem.Application.Features.MenuItems.Queries;
using RestaurantSystem.Domain.Entities;

namespace RestaurantSystem.Tests;

public class MenuItemHandlerTests
{
    private readonly Mock<IMenuItemRepository> _mockRepo;

    public MenuItemHandlerTests()
    {
        _mockRepo = new Mock<IMenuItemRepository>();
    }

    [Fact]
    public async Task CreateMenuItem_ShouldReturnMenuItemDto()
    {
        _mockRepo.Setup(r => r.CreateAsync(It.IsAny<MenuItem>()))
            .ReturnsAsync((MenuItem m) => { m.Id = 1; return m; });

        var handler = new CreateMenuItemCommandHandler(_mockRepo.Object);
        var result = await handler.Handle(new CreateMenuItemCommand("Margherita", "Tomatsås och ost", 95.00m, true, 1), CancellationToken.None);

        result.Should().NotBeNull();
        result.Name.Should().Be("Margherita");
        result.Id.Should().Be(1);
    }

    [Fact]
    public async Task GetMenuItems_ShouldReturnList()
    {
        _mockRepo.Setup(r => r.GetAllAsync())
            .ReturnsAsync(new List<MenuItem>
            {
                new MenuItem { Id = 1, Name = "Margherita", Price = 95m, CategoryId = 1 },
                new MenuItem { Id = 2, Name = "Vesuvio", Price = 105m, CategoryId = 1 }
            });

        var handler = new GetMenuItemsQueryHandler(_mockRepo.Object);
        var result = await handler.Handle(new GetMenuItemsQuery(), CancellationToken.None);

        result.Should().HaveCount(2);
    }

    [Fact]
    public async Task GetMenuItemById_ShouldReturnDto_WhenExists()
    {
        _mockRepo.Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(new MenuItem { Id = 1, Name = "Margherita", Price = 95m, CategoryId = 1 });

        var handler = new GetMenuItemByIdQueryHandler(_mockRepo.Object);
        var result = await handler.Handle(new GetMenuItemByIdQuery(1), CancellationToken.None);

        result.Should().NotBeNull();
        result!.Name.Should().Be("Margherita");
    }

    [Fact]
    public async Task GetMenuItemById_ShouldReturnNull_WhenNotExists()
    {
        _mockRepo.Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((MenuItem?)null);

        var handler = new GetMenuItemByIdQueryHandler(_mockRepo.Object);
        var result = await handler.Handle(new GetMenuItemByIdQuery(99), CancellationToken.None);

        result.Should().BeNull();
    }

    [Fact]
    public async Task UpdateMenuItem_ShouldReturnUpdatedDto_WhenExists()
    {
        _mockRepo.Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(new MenuItem { Id = 1, Name = "Margherita", Price = 95m, CategoryId = 1 });

        var handler = new UpdateMenuItemCommandHandler(_mockRepo.Object);
        var result = await handler.Handle(new UpdateMenuItemCommand(1, "Margherita Extra", "Ny beskrivning", 110m, true, 1), CancellationToken.None);

        result.Should().NotBeNull();
        result!.Name.Should().Be("Margherita Extra");
    }

    [Fact]
    public async Task UpdateMenuItem_ShouldReturnNull_WhenNotExists()
    {
        _mockRepo.Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((MenuItem?)null);

        var handler = new UpdateMenuItemCommandHandler(_mockRepo.Object);
        var result = await handler.Handle(new UpdateMenuItemCommand(99, "Test", null, 100m, true, 1), CancellationToken.None);

        result.Should().BeNull();
    }

    [Fact]
    public async Task DeleteMenuItem_ShouldReturnTrue_WhenExists()
    {
        _mockRepo.Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(new MenuItem { Id = 1, Name = "Margherita" });

        var handler = new DeleteMenuItemCommandHandler(_mockRepo.Object);
        var result = await handler.Handle(new DeleteMenuItemCommand(1), CancellationToken.None);

        result.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteMenuItem_ShouldReturnFalse_WhenNotExists()
    {
        _mockRepo.Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((MenuItem?)null);

        var handler = new DeleteMenuItemCommandHandler(_mockRepo.Object);
        var result = await handler.Handle(new DeleteMenuItemCommand(99), CancellationToken.None);

        result.Should().BeFalse();
    }
}