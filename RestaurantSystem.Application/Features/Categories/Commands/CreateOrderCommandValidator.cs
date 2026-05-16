using FluentValidation;

namespace RestaurantSystem.Application.Features.Orders.Commands;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(command => command.CustomerName)
            .NotEmpty()
            .WithMessage("Customer name is required.")
            .MaximumLength(100)
            .WithMessage("Customer name cannot be longer than 100 characters.");

        RuleFor(command => command.CustomerEmail)
            .NotEmpty()
            .WithMessage("Customer email is required.")
            .EmailAddress()
            .WithMessage("Customer email must be valid.");

        RuleFor(command => command.OrderItems)
            .NotEmpty()
            .WithMessage("Order must contain at least one order item.");

        RuleForEach(command => command.OrderItems)
            .ChildRules(item =>
            {
                item.RuleFor(orderItem => orderItem.MenuItemId)
                    .GreaterThan(0)
                    .WithMessage("Menu item id must be greater than 0.");

                item.RuleFor(orderItem => orderItem.Quantity)
                    .GreaterThan(0)
                    .WithMessage("Quantity must be greater than 0.");
            });
    }
}
