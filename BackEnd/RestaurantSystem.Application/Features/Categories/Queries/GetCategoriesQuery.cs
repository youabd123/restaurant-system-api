using MediatR;
using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Application.Features.Categories.DTOs;

namespace RestaurantSystem.Application.Features.Categories.Queries;

public record GetCategoriesQuery : IRequest<List<CategoryDto>>;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync();

        return categories
            .Select(category => new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            })
            .ToList();
    }
}

