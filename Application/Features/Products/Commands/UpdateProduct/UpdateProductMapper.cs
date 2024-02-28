using AutoMapper;
using Domin.Entities.Product;

namespace Application.Features.Products.Commands.UpdateProduct;

public sealed class UpdateProductMapper : Profile
{
    public UpdateProductMapper()
    {
        CreateMap<Product, UpdateProductResponse>();
    }
}