using Application.Repository;
using AutoMapper;
using MediatR;

namespace Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductHandler : IRequestHandler<GetAllProductRequest, GetAllProductResponse>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;


    public GetAllProductHandler(IProductRepository productRepository, IMapper mapper
    )
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<GetAllProductResponse> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
    {
        var productList = await _productRepository.GetAllProducts();

        var response = _mapper.Map<GetAllProductResponse>(new GetAllProductResponse { Products = productList });
        return response;
    }
}