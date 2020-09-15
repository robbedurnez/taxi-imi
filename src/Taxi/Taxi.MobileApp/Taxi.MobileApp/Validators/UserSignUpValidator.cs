using System.Text;
using FluentValidation;
using Taxi.Domain.DTO;

namespace Taxi.MobileApp.Validators
{
    public class UserSignUpValidator : AbstractValidator<UserPostDto>
    {
        public UserSignUpValidator()
        {
            RuleFor(u => u.FirstName)
                .NotEmpty()
                .WithMessage("First name cannot be empty");

            RuleFor(u => u.LastName)
                .NotEmpty()
                .WithMessage("Last name cannot be empty");

            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("Email address is not valid")
                .NotEmpty()
                .WithMessage("Email address cannot be empty");

            RuleFor(u => u.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number cannot be empty")
                .Length(10)
                .WithMessage("Phone number must be 10 characters long")
                .Matches(@"^0\d{9}$")
                .WithMessage("Phone number must start with 0");

            RuleFor(u => u.Password)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})")
                .WithMessage(new StringBuilder()
                    .Append("Password must contain:").AppendLine()
                    .Append("- lowercase character").AppendLine()
                    .Append("- uppercase character").AppendLine()
                    .Append("- digit").AppendLine()
                    .Append("- special character: !, @, #, $, %, ^, &, *").AppendLine()
                    .Append("- at least 8 characters").AppendLine()
                    .ToString());
        }
    }
}