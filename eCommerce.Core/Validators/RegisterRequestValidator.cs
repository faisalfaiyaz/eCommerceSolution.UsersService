using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        //Email
        RuleFor(rr => rr.Email)
          .NotEmpty().WithMessage("Email is required")
          .EmailAddress().WithMessage("Invalid email address format");

        //Password
        RuleFor(rr => rr.Password)
          .NotEmpty().WithMessage("Password is required");

        // Validate the PersonName property.
        RuleFor(rr => rr.PersonName)
            .NotEmpty().WithMessage("PersonName is required")
            .Length(1, 50).WithMessage("Person Name should be 1 to 50 characters long");

        // Validate the Gender property.
        RuleFor(rr => rr.Gender)
            .IsInEnum().WithMessage("Invalid gender option");
    }
}
