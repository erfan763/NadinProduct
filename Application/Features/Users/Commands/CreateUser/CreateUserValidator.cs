using FluentValidation;

namespace Application.Features.Users.Commands.CreateUser;

public sealed class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator()
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
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one numeric digit.")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
    }
}