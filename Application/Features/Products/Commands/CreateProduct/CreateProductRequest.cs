using System.Text.Json.Serialization;
using MediatR;

namespace Application.Features.Products.Commands.CreateProduct;

public sealed record CreateProductRequest(string Description, string ProductName) : IRequest<CreateProductResponse>
{
    [JsonIgnore] public string userId;
}