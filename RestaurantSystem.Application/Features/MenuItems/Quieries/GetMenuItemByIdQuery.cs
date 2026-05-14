using AutoMapper;
using MediatR;
using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Application.Features.MenuItems.DTOs;

namespace RestaurantSystem.Application.Features.MenuItems.Queries;

public record GetMenuItemByIdQuery(int Id) : IRequest<MenuItemDto?>;

public class GetMenuItemByIdHandler : IRequestHandler<GetMenuItemByIdQuery, MenuItemDto?>
{
    private readonly IMenuItemRepository _repository;
    private readonly IMapper _mapper;

    public GetMenuItemByIdHandler(IMenuItemRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MenuItemDto?> Handle(GetMenuItemByIdQuery request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id);
        if (item is null) return null;
        return _mapper.Map<MenuItemDto>(item);
    }
}