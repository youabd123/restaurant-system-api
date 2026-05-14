using AutoMapper;
using MediatR;
using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Application.Features.MenuItems.DTOs;
using RestaurantSystem.Domain.Entities;

namespace RestaurantSystem.Application.Features.MenuItems.Commands;

public record CreateMenuItemCommand(string Name, string? Description, decimal Price, int CategoryId) : IRequest<MenuItemDto>;

public class CreateMenuItemHandler : IRequestHandler<CreateMenuItemCommand, MenuItemDto>
{
    private readonly IMenuItemRepository _repository;
    private readonly IMapper _mapper;

    public CreateMenuItemHandler(IMenuItemRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MenuItemDto> Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new MenuItem
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            CategoryId = request.CategoryId
        };

        var created = await _repository.CreateAsync(entity);
        return _mapper.Map<MenuItemDto>(created);
    }
}