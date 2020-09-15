using FluentValidation;
using Taxi.MobileApp.Models;

namespace Taxi.MobileApp.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(a => a.PostalCode)
                .NotEmpty()
                .WithMessage("Postal code is required")
                .Length(4)
                .WithMessage("Postal code has to be 4 characters long");

            RuleFor(a => a.AddressLine1)
                .NotEmpty()
                .WithMessage("Address line 1 cannot be empty");

            RuleFor(a => a.City)
                .NotEmpty()
                .WithMessage("City cannot be empty");
        }
    }
}
