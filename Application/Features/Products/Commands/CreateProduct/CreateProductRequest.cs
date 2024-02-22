using MediatR;

namespace Application.Features.Products.Commands.CreateProduct;

public sealed record CreateProductRequest
    (string userId, string ProductName, string Description) : IRequest<CreateProductResponse>;

public sealed record CreateProductRequestInputs
    (string ProductName, string Description) : IRequest<CreateProductResponse>;