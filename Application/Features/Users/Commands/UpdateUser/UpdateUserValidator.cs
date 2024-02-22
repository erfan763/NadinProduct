using FluentValidation;

namespace Application.Features.Users.Commands.UpdateUser;

public sealed class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress().WithMessage("your email is not valid");
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name should not be empty").MinimumLength(3)
            .WithMessage("Minimum length of the first name is 3 character")
            .MaximumLength(50)
            .WithMessage("your first name is not valid");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name should not be empty").MinimumLength(3)
            .WithMessage("Minimum length of the last name is 3 character")
            .MaximumLength(50)
            .WithMessage("your last name is not valid");
        RuleFor(x => x.UserName).NotEmpty().WithMessage("user name should not be empty").MinimumLength(3)
            .WithMessage("Minimum length of the user name is 3 character")
            .MaximumLength(50)
            .WithMessage("your user name is not valid");
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches("^[0-9]*$").WithMessage("Phone number should contain only numeric digits.")
            .Length(11).WithMessage("Phone number should be 11 digits in length.");
    }
}