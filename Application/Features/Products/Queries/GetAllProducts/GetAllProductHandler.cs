using Application.Repository;
using AutoMapper;
using MediatR;

namespace Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductHandler : IRequestHandler<GetAllProductRequest, GetAllProductResponse>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;


    public GetAllProductHandler(IProductRepository productRepository, IMapper mapper, IUserRepository userRepository
    )
    {
        _productRepository = productRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetAllProductResponse> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
    {
        var productList = await _productRepository.GetAllProducts();
        var user = _userRepository.GetUsers();
        var response = _mapper.Map<GetAllProductResponse>(new GetAllProductResponse { Products = productList });

        if (request.creatorUserName is null) return response;

        return response;
    }
}