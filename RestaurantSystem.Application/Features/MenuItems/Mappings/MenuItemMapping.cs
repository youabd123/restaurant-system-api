using AutoMapper;
using RestaurantSystem.Application.Features.MenuItems.DTOs;
using RestaurantSystem.Domain.Entities;

namespace RestaurantSystem.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MenuItem, MenuItemDto>();
    }
}