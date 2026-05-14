using MediatR;
using RestaurantSystem.Application.Common.Interfaces;

namespace RestaurantSystem.Application.Features.MenuItems.Commands;

public record DeleteMenuItemCommand(int Id) : IRequest<bool>;

public class DeleteMenuItemHandler : IRequestHandler<DeleteMenuItemCommand, bool>
{
    private readonly IMenuItemRepository _repo;
    public DeleteMenuItemHandler(IMenuItemRepository repo) => _repo = repo;

    public async Task<bool> Handle(DeleteMenuItemCommand req, CancellationToken ct)
    {
        var entity = await _repo.GetByIdAsync(req.Id);
        if (entity == null) return false;

        await _repo.DeleteAsync(entity);
        return true;
    }
}