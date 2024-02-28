using MediatR;

namespace Application.Features.Products.Queries.GetProductById;

public sealed record GetProductByIdRequest(string Id) : IRequest<GetProductByIdResponse>;