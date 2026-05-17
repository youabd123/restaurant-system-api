using FluentValidation;

namespace RestaurantSystem.Application.Features.Orders.Commands;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    private static readonly string[] AllowedStatuses =
    {
        "Pending",
        "Completed",
        "Cancelled"
    };

    public UpdateOrderCommandValidator()
    {
        RuleFor(command => command.Id)
            .GreaterThan(0)
            .WithMessage("Order id must be greater than 0.");

        RuleFor(command => command.Status)
            .NotEmpty()
            .WithMessage("Status is required.")
            .Must(status => AllowedStatuses.Contains(status))
            .WithMessage("Status must be Pending, Completed, or Cancelled.");
    }
}
