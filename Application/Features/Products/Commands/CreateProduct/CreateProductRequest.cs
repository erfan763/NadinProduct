using System.Text.Json.Serialization;
using MediatR;

namespace Application.Features.Products.Commands.CreateProduct;

public sealed record CreateProductRequest : IRequest<CreateProductResponse>
{
    public string Description;
    public string ProductName;
    [JsonIgnore] public string userId;
}