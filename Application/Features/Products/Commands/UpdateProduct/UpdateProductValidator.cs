using FluentValidation;

namespace Application.Features.Products.Commands.UpdateProduct;

public sealed class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.ProductName).NotEmpty().WithMessage("ProductName should not be empty").MinimumLength(3)
            .WithMessage("min length of product name should be 3 character").MaximumLength(50)
            .WithMessage("max length of the product name is 50 character");
        RuleFor(x => x.IsAvailable).NotEmpty().WithMessage("is available should not be empty");
    }
}