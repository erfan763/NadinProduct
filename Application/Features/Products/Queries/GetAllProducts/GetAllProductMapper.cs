using AutoMapper;
using Domin.Entities.Product;

namespace Application.Features.Products.Queries.GetAllProducts;

public sealed class GetAllProductMapper : Profile
{
    public GetAllProductMapper()
    {
        CreateMap<List<Product>, GetAllProductResponse>()
            .ForMember(dest => dest.Products, act => act.MapFrom(src => src));
    }
}