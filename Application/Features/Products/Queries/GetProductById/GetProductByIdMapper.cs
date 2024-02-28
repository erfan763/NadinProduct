using AutoMapper;
using Domin.Entities.Product;

namespace Application.Features.Products.Queries.GetProductById;

public sealed class GetProductByIdMapper : Profile
{
    public GetProductByIdMapper()
    {
        CreateMap<Product, GetProductByIdResponse>();
    }
}