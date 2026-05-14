using AutoMapper; // Fixar rött streck på "Profile"
using RestaurantSystem.Application.Features.Categories.DTOs; // Fixar rött streck på "CategoryDto"
using RestaurantSystem.Domain.Entities; // Fixar rött streck på "Category"

namespace RestaurantSystem.Application.Features.Categories.Mappings;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, CategoryDto>();
    }
}