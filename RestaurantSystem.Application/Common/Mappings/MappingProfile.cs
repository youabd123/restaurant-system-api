using AutoMapper;
using RestaurantSystem.Application.Features.Categories.DTOs;
using RestaurantSystem.Application.Features.MenuItems.DTOs;
using RestaurantSystem.Application.Features.Orders.DTOs;
using RestaurantSystem.Domain.Entities;

namespace RestaurantSystem.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<MenuItem, MenuItemDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null));
        CreateMap<Order, OrderDto>();
        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(dest => dest.MenuItemName, opt => opt.MapFrom(src => src.MenuItem != null ? src.MenuItem.Name : null));
    }
}