using AutoMapper;
using Domin.Entities.Product;

namespace Application.Features.Products.Queries.GetAllProducts;

public sealed class GetAllProductMapper : Profile
{
    public GetAllProductMapper()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<List<ProductDto>, GetAllProductResponse>()
            .ForMember(dest => dest.Products, act => act.MapFrom(src => src));
    }
}