using AutoMapper;
using Domin.Entities.Product;

namespace Application.Features.Products.Commands.CreateProduct;

public sealed class CreateProductMapper : Profile
{
    public CreateProductMapper()
    {
        CreateMap<Product, CreateProductResponse>();
        CreateMap<CreateProductResponse, Product>();
    }
}