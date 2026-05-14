using AutoMapper;
using MediatR;
using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Application.Features.MenuItems.DTOs;

namespace RestaurantSystem.Application.Features.MenuItems.Queries;

public record GetMenuItemsQuery : IRequest<List<MenuItemDto>>;

public class GetMenuItemsHandler : IRequestHandler<GetMenuItemsQuery, List<MenuItemDto>>
{
    private readonly IMenuItemRepository _repository;
    private readonly IMapper _mapper;

    public GetMenuItemsHandler(IMenuItemRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<MenuItemDto>> Handle(GetMenuItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await _repository.GetAllAsync();
        return _mapper.Map<List<MenuItemDto>>(items);
    }
}