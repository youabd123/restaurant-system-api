using MediatR;
using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Application.Features.Categories.DTOs;

namespace RestaurantSystem.Application.Features.Categories.Commands;

public record UpdateCategoryCommand(int Id, string Name, string? Description) : IRequest<CategoryDto?>;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto?>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryDto?> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);

        if (category is null)
        {
            return null;
        }

        category.Name = request.Name;
        category.Description = request.Description;

        await _categoryRepository.UpdateAsync(category);

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
    }
}
