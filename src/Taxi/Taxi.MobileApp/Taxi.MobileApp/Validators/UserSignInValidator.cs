using FluentValidation;
using Taxi.Domain.DTO;

namespace Taxi.MobileApp.Validators
{
    public class UserSignInValidator : AbstractValidator<UserLoginDto>
    {
        public UserSignInValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("Email address is not valid")
                .NotEmpty()
                .WithMessage("Email address cannot be empty");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Password cannot be empty");
        }
    }
}