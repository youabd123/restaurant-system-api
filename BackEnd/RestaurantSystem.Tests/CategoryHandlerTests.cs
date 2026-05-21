using FluentAssertions;
using Moq;
using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Application.Features.Categories.Commands;
using RestaurantSystem.Application.Features.Categories.DTOs;
using RestaurantSystem.Application.Features.Categories.Queries;
using RestaurantSystem.Domain.Entities;

namespace RestaurantSystem.Tests;

public class CategoryHandlerTests
{
    private readonly Mock<ICategoryRepository> _mockRepo;

    public CategoryHandlerTests()
    {
        _mockRepo = new Mock<ICategoryRepository>();
    }

    // CREATE
    [Fact]
    public async Task CreateCategory_ShouldReturnCategoryDto()
    {
        var command = new CreateCategoryCommand("Pizzor", "Stenugnsbakade pizzor");

        _mockRepo.Setup(r => r.CreateAsync(It.IsAny<Category>()))
            .ReturnsAsync((Category c) => { c.Id = 1; return c; });

        var handler = new CreateCategoryCommandHandler(_mockRepo.Object);
        var result = await handler.Handle(command, CancellationToken.None);

        result.Should().NotBeNull();
        result.Name.Should().Be("Pizzor");
        result.Id.Should().Be(1);
    }

    // GET ALL
    [Fact]
    public async Task GetCategories_ShouldReturnListOfCategoryDto()
    {
        _mockRepo.Setup(r => r.GetAllAsync())
            .ReturnsAsync(new List<Category>
            {
                new Category { Id = 1, Name = "Pizzor", Description = "Stenugnsbakade pizzor" },
                new Category { Id = 2, Name = "Pasta", Description = "Färsk pasta" }
            });

        var handler = new GetCategoriesQueryHandler(_mockRepo.Object);
        var result = await handler.Handle(new GetCategoriesQuery(), CancellationToken.None);

        result.Should().HaveCount(2);
        result[0].Name.Should().Be("Pizzor");
    }

    // GET BY ID
    [Fact]
    public async Task GetCategoryById_ShouldReturnCategoryDto_WhenExists()
    {
        _mockRepo.Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(new Category { Id = 1, Name = "Pizzor", Description = "Stenugnsbakade pizzor" });

        var handler = new GetCategoryByIdQueryHandler(_mockRepo.Object);
        var result = await handler.Handle(new GetCategoryByIdQuery(1), CancellationToken.None);

        result.Should().NotBeNull();
        result!.Name.Should().Be("Pizzor");
    }

    [Fact]
    public async Task GetCategoryById_ShouldReturnNull_WhenNotExists()
    {
        _mockRepo.Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((Category?)null);

        var handler = new GetCategoryByIdQueryHandler(_mockRepo.Object);
        var result = await handler.Handle(new GetCategoryByIdQuery(99), CancellationToken.None);

        result.Should().BeNull();
    }

    // UPDATE
    [Fact]
    public async Task UpdateCategory_ShouldReturnUpdatedDto_WhenExists()
    {
        _mockRepo.Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(new Category { Id = 1, Name = "Pizzor", Description = "Gammal beskrivning" });

        var handler = new UpdateCategoryCommandHandler(_mockRepo.Object);
        var result = await handler.Handle(new UpdateCategoryCommand(1, "Pizzor Uppdaterad", "Ny beskrivning"), CancellationToken.None);

        result.Should().NotBeNull();
        result!.Name.Should().Be("Pizzor Uppdaterad");
    }

    [Fact]
    public async Task UpdateCategory_ShouldReturnNull_WhenNotExists()
    {
        _mockRepo.Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((Category?)null);

        var handler = new UpdateCategoryCommandHandler(_mockRepo.Object);
        var result = await handler.Handle(new UpdateCategoryCommand(99, "Test", null), CancellationToken.None);

        result.Should().BeNull();
    }

    // DELETE
    [Fact]
    public async Task DeleteCategory_ShouldReturnTrue_WhenExists()
    {
        _mockRepo.Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(new Category { Id = 1, Name = "Pizzor" });

        var handler = new DeleteCategoryCommandHandler(_mockRepo.Object);
        var result = await handler.Handle(new DeleteCategoryCommand(1), CancellationToken.None);

        result.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteCategory_ShouldReturnFalse_WhenNotExists()
    {
        _mockRepo.Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((Category?)null);

        var handler = new DeleteCategoryCommandHandler(_mockRepo.Object);
        var result = await handler.Handle(new DeleteCategoryCommand(99), CancellationToken.None);

        result.Should().BeFalse();
    }
}