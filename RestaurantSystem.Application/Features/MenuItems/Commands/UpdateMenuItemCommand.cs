using AutoMapper;
using MediatR;
using RestaurantSystem.Application.Common.Interfaces;
using RestaurantSystem.Application.Features.MenuItems.DTOs;

namespace RestaurantSystem.Application.Features.MenuItems.Commands;

public record UpdateMenuItemCommand(int Id, string Name, string? Description, decimal Price, int CategoryId) : IRequest<MenuItemDto?>;

public class UpdateMenuItemHandler : IRequestHandler<UpdateMenuItemCommand, MenuItemDto?>
{
    private readonly IMenuItemRepository _repository;
    private readonly IMapper _mapper;

    public UpdateMenuItemHandler(IMenuItemRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MenuItemDto?> Handle(UpdateMenuItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);

        if (entity is null)
            return null;

        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.Price = request.Price;
        entity.CategoryId = request.CategoryId;

        await _repository.UpdateAsync(entity);

        return _mapper.Map<MenuItemDto>(entity);
    }
}