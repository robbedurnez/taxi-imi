using FluentValidation;
using Taxi.MobileApp.Models;

namespace Taxi.MobileApp.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(o => o.FromId)
                .NotEqual(o => o.ToId)
                .WithMessage("Addresses cannot be equal")
                .NotNull()
                .WithMessage("Address cannot be null");

            RuleFor(o => o.ToId)
                .NotNull()
                .WithMessage("Address cannot be null");
        }
    }
}