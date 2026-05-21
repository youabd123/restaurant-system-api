using MediatR;
using RestaurantSystem.Application.Common.Interfaces;

namespace RestaurantSystem.Application.Features.MenuItems.Commands;

public record DeleteMenuItemCommand(int Id) : IRequest<bool>;

public class DeleteMenuItemCommandHandler : IRequestHandler<DeleteMenuItemCommand, bool>
{
    private readonly IMenuItemRepository _menuItemRepository;

    public DeleteMenuItemCommandHandler(IMenuItemRepository menuItemRepository)
    {
        _menuItemRepository = menuItemRepository;
    }

    public async Task<bool> Handle(DeleteMenuItemCommand request, CancellationToken cancellationToken)
    {
        var menuItem = await _menuItemRepository.GetByIdAsync(request.Id);

        if (menuItem is null)
        {
            return false;
        }

        await _menuItemRepository.DeleteAsync(menuItem);

        return true;
    }
}
