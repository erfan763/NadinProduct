using MediatR;

namespace Application.Features.Products.Queries.GetAllProducts;

public sealed record GetAllProductRequest : IRequest<GetAllProductResponse>
{
}