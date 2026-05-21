using FluentValidation;

namespace RestaurantSystem.Application.Features.Categories.Commands;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(command => command.Id)
            .GreaterThan(0)
            .WithMessage("Category id must be greater than 0.");

        RuleFor(command => command.Name)
            .NotEmpty()
            .WithMessage("Category name is required.")
            .MaximumLength(100)
            .WithMessage("Category name cannot be longer than 100 characters.");

        RuleFor(command => command.Description)
            .MaximumLength(500)
            .WithMessage("Description cannot be longer than 500 characters.");
    }
}
