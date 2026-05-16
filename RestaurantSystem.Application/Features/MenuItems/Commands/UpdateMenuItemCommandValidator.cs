using FluentValidation;

namespace RestaurantSystem.Application.Features.MenuItems.Commands;

public class UpdateMenuItemCommandValidator : AbstractValidator<UpdateMenuItemCommand>
{
    public UpdateMenuItemCommandValidator()
    {
        RuleFor(command => command.Id)
            .GreaterThan(0)
            .WithMessage("Menu item id must be greater than 0.");

        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage("Menu item name is required.")
            .MaximumLength(100)
            .WithMessage("Menu item name cannot be longer than 100 characters.");

        RuleFor(command => command.Description)
            .MaximumLength(500)
            .WithMessage("Description cannot be longer than 500 characters.");

        RuleFor(command => command.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0.");

        RuleFor(command => command.CategoryId)
            .GreaterThan(0)
            .WithMessage("Category id must be greater than 0.");
    }
}
