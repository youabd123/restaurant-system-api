using MediatR;
using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Application.Features.Categories.DTOs;
using RestaurantSystem.Domain.Entities;

namespace RestaurantSystem.Application.Features.Categories.Commands;

public record CreateCategoryCommand(string Name, string? Description) : IRequest<CategoryDto>;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Name = request.Name,
            Description = request.Description
        };

        var createdCategory = await _categoryRepository.CreateAsync(category);

        return new CategoryDto
        {
            Id = createdCategory.Id,
            Name = createdCategory.Name,
            Description = createdCategory.Description
        };
    }
}
