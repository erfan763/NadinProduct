using System.Text.Json.Serialization;
using MediatR;

namespace Application.Features.Products.Commands.UpdateProduct;

public sealed record UpdateProductRequest
    (string Description, string ProductName, bool IsAvailable) : IRequest<UpdateProductResponse>
{
    [JsonIgnore] public string productId;
    [JsonIgnore] public string userId;
}